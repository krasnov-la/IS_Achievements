using Auth;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Authorize(Policy = PolicyData.AdminOnlyPolicyName)]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    AppDbContext _db;
    public AdminController(AppDbContext dbContext)
    {
        _db = dbContext;
    }

    [HttpGet("[action]")]
    public IActionResult Requests()
    {
        return Ok(_db.VerificationRequests
            .Where(r => r.IsOpen)
            .OrderBy(r => r.DateTime)
            .Select(r => new
            {
                r.Id,
                r.EventName,
                r.Description,
                r.DateTime,
                r.OwnerLogin
            }));
    }

    [HttpPost("[action]")]
    public IActionResult Score([FromBody] ScoreRequest request)
    {
        var loginClaim = HttpContext.User.FindFirst(c => c.Type == "Login");
        if (loginClaim is null)
            return BadRequest("User not authenticated");

        var login = loginClaim.Value;

        var verificationReq = _db.VerificationRequests.Find(request.ReqId);
        if (verificationReq is null) return BadRequest("Request not found");

        verificationReq.IsOpen = false;
        _db.Update(verificationReq);

        var achievementId = Guid.NewGuid();

        _db.Achievements.Add(new Achievement(){
            Id = achievementId,
            Score = request.Score,
            VerificationDatetime = DateTime.Now,
            RequestId = verificationReq.Id,
            AdminLogin = login
        });

        _db.SaveChanges();

        return Ok(achievementId);
    }

    [HttpPost("[action]")]
    public IActionResult Comment([FromBody] CommentRequest request)
    {
        var verificationReq = _db.VerificationRequests.Find(request.ReqId);
        if (verificationReq is null) return BadRequest("Request not found");

        var commId = Guid.NewGuid();

        _db.Comments.Add(new Comment(){
            Id = commId,
            Datetime = DateTime.Now,
            Text = request.Text,
            RequestId = request.ReqId
        });

        _db.SaveChanges();
        return Ok(commId);
    }

    [HttpPost("[action]")]
    public IActionResult Activity([FromBody] ActivityRequest request)
    {
        var loginClaim = HttpContext.User.FindFirst(c => c.Type == "Login");
        if (loginClaim is null)
            return BadRequest("User not authenticated");

        var login = loginClaim.Value;

        var actId = Guid.NewGuid();
        _db.Activities.Add(new Activity(){
            Id = actId,
            Name = request.Name,
            Datetime = request.DateTime,
            Link = request.Link,
            AdminLogin = login
        });

        return Ok(actId);
    }
}