using Auth;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class AchievementsController(IUnitOfWork unit) : ControllerBase
{
    readonly IUnitOfWork _unit = unit;

    [HttpPost]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> Create([FromBody] ScoreRequest request)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var login = HttpContext.User.FindFirst(c => c.Type == "Login").Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        var verificationReq = await _unit.Requests.GetById(request.ReqId);
        if (verificationReq is null) return NotFound("Request not found");

        verificationReq.IsOpen = false;
        _unit.Requests.Update(verificationReq);

        var achievement = new Achievement()
        {
            Score = request.Score,
            VerificationDatetime = DateTime.Now,
            RequestId = verificationReq.Id,
            AdminLogin = login
        };

        _unit.Achievements.Insert(achievement);

        await _unit.SaveAsync();
        return Ok(achievement.Id);
    }

    [HttpGet("self")]
    [Authorize]
    public async Task<IActionResult> SelfAchievements()
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var login = HttpContext.User.FindFirst(c => c.Type == "Login").Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        return Ok(await _unit.Achievements
            .GetQuerable()
            .Include(a => a.Request)
            .Where(a => a.Request.OwnerLogin == login)
            .OrderByDescending(a => a.VerificationDatetime)
            .Select(a => new{
                a.AdminLogin,
                a.Score,
                a.Id,
                a.RequestId,
                a.VerificationDatetime
            }).ToListAsync());
    }

    [HttpGet("user/{login}")]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> ReadPerUser([FromRoute] string login)
    {
        return Ok(await _unit.Achievements
            .GetQuerable()
            .Include(a => a.Request)
            .Where(a => a.Request.OwnerLogin == login)
            .OrderByDescending(a => a.VerificationDatetime)
            .Select(a => new{
                a.AdminLogin,
                a.Score,
                a.Id,
                a.RequestId,
                a.VerificationDatetime
            })
            .ToListAsync());
    }

    [HttpPatch("{id}/score/{newScore}")]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> ChangeScore([FromRoute] Guid id, [FromRoute] float newScore)
    {
        var achievement = await _unit.Achievements.GetById(id);
        if (achievement is null) return NotFound();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var login = HttpContext.User.FindFirst(c => c.Type == "Login").Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        achievement.AdminLogin = login;
        achievement.VerificationDatetime = DateTime.Now;
        achievement.Score = newScore;

        _unit.Achievements.Update(achievement);
        await _unit.SaveAsync();

        return Ok();
    }

    //TODO: Удаление
}