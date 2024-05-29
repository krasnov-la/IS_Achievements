using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using Services;

namespace Controllers;

[Route("[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    AppDbContext _db;
    public StudentController(AppDbContext dbContext)
    {
        _db = dbContext;
    }

    [HttpGet("[action]"), Authorize]
    public IActionResult GetRating()
    {
        var loginClaim = HttpContext.User.FindFirst(c => c.Type == "Login");
        if (loginClaim is null)
            return BadRequest("User not authenticated");

        var login = loginClaim.Value;

        var ratingList = (from verificationRequests in _db.VerificationRequests
                          join achievements in _db.Achievements on verificationRequests.Id equals achievements.RequestId
                          join users in _db.Users on verificationRequests.OwnerLogin equals users.Login
                          group achievements.Score by users.Login into allData
                          select new
                          {
                              Login = allData.Key,
                              Score = allData.Select(x => x).Sum()
                          })
                        .OrderByDescending(x => x.Score)
                        .ToList()
                        .Select((x, index) => new
                        {
                            Place = index + 1,
                            x.Login,
                            x.Score
                        });
        var ratingPlace = ratingList.Where(x => x.Login == login)
                                    .Select(x => x.Place)
                                    .FirstOrDefault();

        return Ok(ratingPlace);
    }

    [HttpGet("[action]"), Authorize]
    public IActionResult GetAchievements()
    {
        var loginClaim = HttpContext.User.FindFirst(c => c.Type == "Login");
        if (loginClaim is null)
            return BadRequest("User not authenticated");

        var login = loginClaim.Value;

        var achievementsList = (from verificationRequests in _db.VerificationRequests
                                join achievements in _db.Achievements on verificationRequests.Id equals achievements.RequestId
                                join users in _db.Users on verificationRequests.OwnerLogin equals users.Login
                                join images in _db.Images on verificationRequests.Id equals images.RequestId
                                where users.Login == login
                                where verificationRequests.IsOpen == false
                                select new
                                {
                                    verificationRequests.EventName,
                                    verificationRequests.Description,
                                    achievements.Score,
                                    images.FileName
                                })
                        .ToList();

        return Ok(achievementsList);
    }

    [HttpGet("[action]"), Authorize]
    public IActionResult GetRequests()
    {
        var loginClaim = HttpContext.User.FindFirst(c => c.Type == "Login");
        if (loginClaim is null)
            return BadRequest("User not authenticated");

        var login = loginClaim.Value;

        var achievementsList = (from verificationRequests in _db.VerificationRequests
                                join users in _db.Users on verificationRequests.OwnerLogin equals users.Login
                                join images in _db.Images on verificationRequests.Id equals images.RequestId
                                where users.Login == login
                                where verificationRequests.IsOpen == true
                                select new
                                {
                                    verificationRequests.EventName,
                                    verificationRequests.Description,
                                    images.FileName
                                })
                        .ToList();

        return Ok(achievementsList);
    }
}