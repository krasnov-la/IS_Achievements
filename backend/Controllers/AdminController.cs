using Auth;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers;

[ApiController]
[Authorize(Policy = PolicyData.AdminOnlyPolicyName)]
[Route("[controller]")]
public class AdminController(IUnitOfWork unit) : ControllerBase
{
    readonly IUnitOfWork _unit = unit;

    [HttpPost("[action]")]
    public async Task<IActionResult> Score([FromBody] ScoreRequest request)
    {
        var login = HttpContext.User.FindFirst(c => c.Type == "Login")?.Value;
        if (login is null) return BadRequest("User not authenticated");

        var verificationReq = await _unit.Requests.GetById(request.ReqId);
        if (verificationReq is null) return BadRequest("Request not found");

        verificationReq.IsOpen = false;
        _unit.Requests.Update(verificationReq);

        var achievementId = Guid.NewGuid();

        _unit.Achievements.Insert(new Achievement()
        {
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