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

    [HttpPost]
    public async Task<IActionResult> CreateActivity([FromBody] ActivityRequest request)
    {
        var loginClaim = HttpContext.User.FindFirst(c => c.Type == "Login");
        if (loginClaim is null)
            return BadRequest("User not authenticated");

        var login = loginClaim.Value;

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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateActivity([FromBody] ActivityRequest request, [FromRoute] Guid id)
    {
        var login = HttpContext.User.FindFirst(c => c.Type == "Login")?.Value;
        if (login is null) return BadRequest("User not authenticated");

        var activity = await _unit.Activities.GetById(id);
        if (activity is null) return NotFound();

        activity.Name = request.Name;
        activity.Link = request.Link;
        activity.Datetime = request.DateTime;
        _unit.Activities.Update(activity);

        await _unit.SaveAsync();
        return Ok();
    }

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