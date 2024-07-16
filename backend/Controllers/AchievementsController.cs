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

    /// <summary>
    /// Creates a new achievement.
    /// </summary>
    /// <param name="request">The score request details.</param>
    /// <response code="200">Achievement created successfully.</response>
    /// <response code="404">Request not found.</response>
    /// <remarks>
    /// This method creates a new achievement based on the provided score request.
    /// This method can only be accessed by users with the "Admin" role.
    /// 
    /// **Example request:**
    /// ```
    /// POST /Achievements
    /// {
    ///    "ReqId": "123e4567-e89b-12d3-a456-426614174000",
    ///    "Score": 95.5
    /// }
    /// ```
    /// **Example response:**
    /// ```json
    /// "123e4567-e89b-12d3-a456-426614174000"
    /// ```
    /// </remarks>
    [HttpPost]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> Create([FromBody] ScoreRequest request)
    {
        var login = HttpContext.User.Claims.First(c => c.Type == "Login").Value;

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

    /// <summary>
    /// Retrieves achievements for the current user.
    /// </summary>
    /// <response code="200">Achievements retrieved successfully.</response>
    /// <remarks>
    /// This method retrieves the achievements for the current user based on their login.
    /// This method can be accessed by authorized users.
    /// 
    /// **Example request:**
    /// ```
    /// GET /Achievements/self
    /// ```
    /// **Example response:**
    /// ```json
    /// [
    ///     {
    ///         "adminLogin": "admin1",
    ///         "score": 95.5,
    ///         "id": "123e4567-e89b-12d3-a456-426614174000",
    ///         "requestId": "123e4567-e89b-12d3-a456-426614174000",
    ///         "verificationDatetime": "2024-07-11T12:00:00Z"
    ///     },
    ///     ...
    /// ]
    /// ```
    /// </remarks>
    [HttpGet("self")]
    [Authorize]
    public async Task<IActionResult> SelfAchievements()
    {
        var login = HttpContext.User.Claims.First(c => c.Type == "Login").Value;
        return Ok(await _unit.Achievements
            .GetQuerable()
            .Include(a => a.Request)
            .Where(a => a.Request.OwnerLogin == login)
            .OrderByDescending(a => a.VerificationDatetime)
            .Select(a => new
            {
                //a.AdminLogin, зачем палить логин админа пользаку?
                a.Score,
                a.Id,
                a.RequestId,
                a.VerificationDatetime,
                a.Request.Description,
                a.Request.EventName
            }).ToListAsync());
    }

    /// <summary>
    /// Retrieves achievements for a specific user.
    /// </summary>
    /// <param name="login">The login of the user.</param>
    /// <response code="200">Achievements retrieved successfully.</response>
    /// <remarks>
    /// This method retrieves the achievements for a specific user based on their login.
    /// This method can only be accessed by users with the "Admin" role.
    /// 
    /// **Example request:**
    /// ```
    /// GET /Achievements/user/johndoe
    /// ```
    /// **Example response:**
    /// ```json
    /// [
    ///     {
    ///         "adminLogin": "admin1",
    ///         "score": 95.5,
    ///         "id": "123e4567-e89b-12d3-a456-426614174000",
    ///         "requestId": "123e4567-e89b-12d3-a456-426614174000",
    ///         "verificationDatetime": "2024-07-11T12:00:00Z"
    ///     },
    ///     ...
    /// ]
    /// ```
    /// </remarks>
    [HttpGet("user/{login}")]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> ReadPerUser([FromRoute] string login)
    {
        return Ok(await _unit.Achievements
            .GetQuerable()
            .Include(a => a.Request)
            .Where(a => a.Request.OwnerLogin == login)
            .OrderByDescending(a => a.VerificationDatetime)
            .Select(a => new
            {
                a.AdminLogin,
                a.Score,
                a.Id,
                a.RequestId,
                a.VerificationDatetime
            })
            .ToListAsync());
    }

    /// <summary>
    /// Updates the score of a specific achievement.
    /// </summary>
    /// <param name="id">The ID of the achievement.</param>
    /// <param name="newScore">The new score to set.</param>
    /// <response code="200">Score updated successfully.</response>
    /// <response code="404">Achievement not found.</response>
    /// <remarks>
    /// This method updates the score of an existing achievement.
    /// This method can only be accessed by users with the "Admin" role.
    /// 
    /// Example request:
    /// 
    ///     PATCH /Achievements/123e4567-e89b-12d3-a456-426614174000/score/98.5
    /// </remarks>
    [HttpPatch("{id}/score/{newScore}")]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> ChangeScore([FromRoute] Guid id, [FromRoute] float newScore)
    {
        var achievement = await _unit.Achievements.GetById(id);
        if (achievement is null) return NotFound();

        var login = HttpContext.User.Claims.First(c => c.Type == "Login").Value;

        achievement.AdminLogin = login;
        achievement.VerificationDatetime = DateTime.Now;
        achievement.Score = newScore;

        _unit.Achievements.Update(achievement);
        await _unit.SaveAsync();

        return Ok();
    }

    /// <summary>
    /// Deletes an achievement and reopens the corresponding verification request.
    /// </summary>
    /// <param name="id">The ID of the achievement to delete.</param>
    /// <response code="200">Achievement deleted successfully and corresponding request reopened.</response>
    /// <response code="404">Achievement not found.</response>
    /// <remarks>
    /// This method deletes an existing achievement and reopens the corresponding verification request.
    /// This method can only be accessed by users with the "Admin" role.
    /// 
    /// Example request:
    /// 
    ///     DELETE /Achievements/123e4567-e89b-12d3-a456-426614174000
    /// </remarks>
    [HttpDelete("{id}")]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> DeleteAchievement([FromRoute] Guid id)
    {
        var achievement = await _unit.Achievements
            .GetQuerable()
            .Include(a => a.Request)
            .FirstAsync(a => a.Id == id);
        var request = achievement.Request;
        request.IsOpen = true;
        _unit.Requests.Update(request);
        _unit.Achievements.Delete(achievement);
        await _unit.SaveAsync();
        return Ok();
    }
}
