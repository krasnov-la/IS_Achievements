using Auth;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers;

[ApiController]
[Route("[Controller]")]
[Authorize(Policy = PolicyData.AdminOnlyPolicyName)]
public class ActivitiesController(IUnitOfWork unit) : ControllerBase
{
    readonly IUnitOfWork _unit = unit;

    /// <summary>
    /// Creates a new activity.
    /// </summary>
    /// <param name="request">The activity request details.</param>
    /// <response code="200">Activity created successfully.</response>
    /// <remarks>
    /// This method creates a new activity based on the provided details.
    /// Example request:
    /// 
    ///     POST /Activities
    ///     {
    ///        "Name": "Activity Name",
    ///        "DateTime": "2024-07-11T12:00:00Z",
    ///        "Link": "http://example.com"
    ///     }
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> CreateActivity([FromBody] ActivityRequest request)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var login = HttpContext.User.FindFirst(c => c.Type == "Login").Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        var actId = Guid.NewGuid();

        _unit.Activities.Insert(new Activity()
        {
            Id = actId,
            Name = request.Name,
            Datetime = request.DateTime,
            Link = request.Link,
            AdminLogin = login
        });

        await _unit.SaveAsync();

        return Ok(actId);
    }

    /// <summary>
    /// Retrieves a specific activity by ID.
    /// </summary>
    /// <param name="id">The ID of the activity.</param>
    /// <response code="200">Activity retrieved successfully.</response>
    /// <response code="404">Activity not found.</response>
    /// <remarks>
    /// This method retrieves the details of a specific activity.
    /// Example request:
    /// 
    ///     GET /Activities/123e4567-e89b-12d3-a456-426614174000
    /// </remarks>
    [HttpGet("{id}")]
    public async Task<IActionResult> ReadActivity([FromRoute] Guid id)
    {
        var activity = await _unit.Activities.GetById(id);
        if (activity is null) return NotFound();
        return Ok(
            new
            {
                activity.Id,
                activity.Name,
                activity.Datetime,
                activity.Link
            }
        );
    }

    /// <summary>
    /// Updates an existing activity.
    /// </summary>
    /// <param name="request">The activity request details.</param>
    /// <param name="id">The ID of the activity to update.</param>
    /// <response code="200">Activity updated successfully.</response>
    /// <response code="404">Activity not found.</response>
    /// <remarks>
    /// This method updates an existing activity with the provided details.
    /// Example request:
    /// 
    ///     PUT /Activities/123e4567-e89b-12d3-a456-426614174000
    ///     {
    ///        "Name": "Updated Activity Name",
    ///        "DateTime": "2024-07-12T14:00:00Z",
    ///        "Link": "http://example.com/updated"
    ///     }
    /// </remarks>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateActivity([FromBody] ActivityRequest request, [FromRoute] Guid id)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var login = HttpContext.User.FindFirst(c => c.Type == "Login").Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        var activity = await _unit.Activities.GetById(id);
        if (activity is null) return NotFound();

        activity.Name = request.Name;
        activity.Link = request.Link;
        activity.Datetime = request.DateTime;
        _unit.Activities.Update(activity);

        await _unit.SaveAsync();
        return Ok();
    }

    /// <summary>
    /// Deletes a specific activity by ID.
    /// </summary>
    /// <param name="id">The ID of the activity to delete.</param>
    /// <response code="200">Activity deleted successfully.</response>
    /// <response code="404">Activity not found.</response>
    /// <remarks>
    /// This method deletes a specific activity.
    /// Example request:
    /// 
    ///     DELETE /Activities/123e4567-e89b-12d3-a456-426614174000
    /// </remarks>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity([FromRoute] Guid id)
    {
        var activity = await _unit.Activities.GetById(id);
        if (activity is null) return NotFound();

        _unit.Activities.Delete(activity);
        await _unit.SaveAsync();
        return Ok();
    }
}