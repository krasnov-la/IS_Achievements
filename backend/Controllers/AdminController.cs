using Auth;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers;

[ApiController]
//[Authorize(Policy = PolicyData.AdminOnlyPolicyName)]
[Route("[controller]")]
public class AdminController(IUnitOfWork unit) : ControllerBase
{
    readonly IUnitOfWork _unit = unit;

    [HttpGet("[action]")]
    //Returns all open requests sorted by datetime
    public async Task<IActionResult> Requests()
    {
        var data = await _unit.Requests
            .Get(
                filter: r => r.IsOpen,
                orderBy: r => r.DateTime
            );

        return Ok(data.Select( r => new {
            r.Id,
            r.EventName,
            r.Description,
            r.DateTime,
            r.OwnerLogin
        }));
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Score([FromBody] ScoreRequest request)
    {
        var loginClaim = HttpContext.User.FindFirst(c => c.Type == "Login");
        if (loginClaim is null)
            return BadRequest("User not authenticated");

        var login = loginClaim.Value;

        var verificationReq = await _unit.Requests.GetById(request.ReqId);
        if (verificationReq is null) return BadRequest("Request not found");

        verificationReq.IsOpen = false;
        _unit.Requests.Update(verificationReq);

        var achievementId = Guid.NewGuid();

        _unit.Achievements.Insert(new Achievement(){
            Id = achievementId,
            Score = request.Score,
            VerificationDatetime = DateTime.Now,
            RequestId = verificationReq.Id,
            AdminLogin = login
        });

        await _unit.SaveAsync();

        return Ok(achievementId);
    }
}