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
    IUnitOfWork _unit = unit;

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

    [HttpPost("Comments")]
    public async Task<IActionResult> CreateComment([FromBody] CommentRequest request)
    {
        var verificationReq = await _unit.Requests.GetById(request.ReqId);
        if (verificationReq is null) return BadRequest("Request not found");

        var commId = Guid.NewGuid();

        _unit.Comments.Insert(new Comment(){
            Id = commId,
            Datetime = DateTime.Now,
            Text = request.Text,
            RequestId = request.ReqId
        });

        await _unit.SaveAsync();
        return Ok(commId);
    }

    [HttpGet("Comments/{id}")]
    public async Task<IActionResult> ReadComment([FromRoute] Guid id)
    {
        var comm = await _unit.Comments.GetById(id);
        if (comm is null) return NotFound();
        return Ok(new {
            comm.Id,
            comm.Text,
            comm.Datetime,
            comm.RequestId
        });
    }

    [HttpPut("Comments")]
    public async Task<IActionResult> UpdateComment([FromBody] CommentUpdateRequest request)
    {
        var comm = await _unit.Comments.GetById(request.CommId);
        if (comm is null) return NotFound();
        comm.Text = request.Text;
        _unit.Comments.Update(comm);
        await _unit.SaveAsync();
        return Ok();
    }

    [HttpDelete("Comments/{id}")]
    public async Task<IActionResult> DeleteComment(Guid id)
    {
        var comm = await _unit.Comments.GetById(id);
        if (comm is null) return NotFound();
        _unit.Comments.Delete(comm);
        await _unit.SaveAsync();
        return Ok();
    }

    // [HttpPost("[action]")]
    // public IActionResult Activity([FromBody] ActivityRequest request)
    // {
    //     var loginClaim = HttpContext.User.FindFirst(c => c.Type == "Login");
    //     if (loginClaim is null)
    //         return BadRequest("User not authenticated");

    //     var login = loginClaim.Value;

    //     var actId = Guid.NewGuid();
    //     _db.Activities.Add(new Activity(){
    //         Id = actId,
    //         Name = request.Name,
    //         Datetime = request.DateTime,
    //         Link = request.Link,
    //         AdminLogin = login
    //     });

    //     return Ok(actId);
    // }
}