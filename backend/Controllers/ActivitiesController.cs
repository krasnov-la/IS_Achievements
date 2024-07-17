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
    /// <param name="imageService">The image service for validating image names.</param>
    /// <response code="200">Activity created successfully.</response>
    /// <response code="400">Invalid image name.</response>
    /// <remarks>
    /// This method creates a new activity based on the provided details.
    /// 
    /// **Example request:**
    /// ```
    /// POST /Activities
    /// {
    ///    "Name": "Activity Name",
    ///    "DateTime": "2024-07-11T12:00:00Z",
    ///    "Link": "http://example.com"
    /// }
    /// ```
    /// **Example response:**
    /// ```json
    /// "123e4567-e89b-12d3-a456-426614174000"
    /// ```
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> CreateActivity([FromBody] ActivityRequest request, [FromServices] IImageService imageService)
    {
        var login = HttpContext.User.Claims.First(c => c.Type == "Login").Value;

        var actId = Guid.NewGuid();

        if (!imageService.Validate(request.Preview))
            return BadRequest("Invalid image name");

        _unit.Activities.Insert(new Activity()
        {
            Id = actId,
            Name = request.Name,
            Datetime = request.DateTime,
            Preview = request.Preview,
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
    /// 
    /// **Example request:**
    /// ```
    /// GET /Activities/123e4567-e89b-12d3-a456-426614174000
    /// ```
    /// **Example response:**
    /// ```json
    /// {
    ///    "id": "123e4567-e89b-12d3-a456-426614174000",
    ///    "name": "Activity Name",
    ///    "datetime": "2024-07-11T12:00:00Z",
    ///    "preview": "fab71c65-6bb1-4563-bf4a-550931fbe351.png"
    ///    "link": "http://example.com"
    /// }
    /// ```
    /// </remarks>
    [HttpGet("{id}")]
    public async Task<IActionResult> ReadActivity([FromRoute] Guid id)
    {
        var activity = await _unit.Activities.GetById(id);
        if (activity is null) return NotFound();
        return Ok(activity);
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
    /// 
    //TODO: Split into patches
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateActivity([FromBody] ActivityRequest request, [FromRoute] Guid id)
    {
        var login = HttpContext.User.Claims.First(c => c.Type == "Login").Value;

        var activity = await _unit.Activities.GetById(id);
        if (activity is null) return NotFound();

        activity.Name = request.Name;
        activity.Link = request.Link;
        activity.Preview = request.Preview;
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