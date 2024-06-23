using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using Services;

namespace Controllers;

[Route("[controller]")]
[ApiController]
public class StudentController(AppDbContext dbContext, IImageService imageService) : ControllerBase
{
    AppDbContext _db = dbContext;
    IImageService _imageService = imageService;

    [HttpGet("[action]"), Authorize]
    public IActionResult GetInfo()
    {
        var login = HttpContext.User.FindFirst(c => c.Type == "Login")?.Value;
        if (login is null) return BadRequest("User not authenticated");

        var ratingList = _db.VerificationRequests
        .Join(
            _db.Achievements,
            vr => vr.Id,
            ach => ach.RequestId,
            (vr, ach) => new { vr.OwnerLogin, ach.Score }
        )
        .Join(
            _db.Users,
            vrAch => vrAch.OwnerLogin,
            user => user.Login,
            (vrAch, user) => new { user.Login, user.Nickname, vrAch.Score }
        )
        .GroupBy(
            u => new { u.Login, u.Nickname },
            (key, group) => new
            {
                key.Nickname,
                key.Login,
                Score = group.Sum(x => x.Score),
            }
        )
        .OrderByDescending(x => x.Score)
        .ToList()
        .Select((x, index) => new
        {
            Place = index + 1,
            x.Login,
            x.Score,
            x.Nickname
        });

        var studentInfo = ratingList
        .Where(x => x.Login == login)
        .Select(x => new
        {
            x.Nickname,
            x.Score,
            x.Place
        })
        .FirstOrDefault();

        var StudentResponse = new StudentResponse();

        studentInfo ??= new {
                Nickname = _db.Users.Where(x => x.Login == login).Select(x => x.Nickname).First(),
                Score = 0f,
                Place = 0
            };

        return Ok(new {
            studentInfo.Nickname,
            studentInfo.Score,
            studentInfo.Place
        });
    }

    [HttpGet("[action]"), Authorize]
    public IActionResult GetAchievements()
    {
        var loginClaim = HttpContext.User.FindFirst(c => c.Type == "Login");
        if (loginClaim is null)
            return BadRequest("User not authenticated");

        var login = loginClaim.Value;

        var achievementsList = _db.VerificationRequests
        .Join(
            _db.Achievements,
            verificationRequest => verificationRequest.Id,
            achievement => achievement.RequestId,
            (verificationRequest, achievement) => new
            {
                verificationRequest.Id,
                verificationRequest.Description,
                verificationRequest.EventName,
                verificationRequest.OwnerLogin,
                verificationRequest.IsOpen,
                achievement.Score
            }
        )
        .Join(
            _db.Users,
            vrAch => vrAch.OwnerLogin,
            user => user.Login,
            (vrAch, user) => new
            {
                vrAch.Id,
                vrAch.Description,
                vrAch.EventName,
                vrAch.IsOpen,
                user.Login,
                user.Nickname,
                vrAch.Score
            }
        )
        .Join(
            _db.Images,
            vrAchUser => vrAchUser.Id,
            image => image.RequestId,
            (vrAchUser, image) => new
            {
                image.FileName,
                vrAchUser.Id,
                vrAchUser.Description,
                vrAchUser.EventName,
                vrAchUser.IsOpen,
                vrAchUser.Login,
                vrAchUser.Nickname,
                vrAchUser.Score
            }
        )
        .Where(x => x.Login == login && !x.IsOpen)
        .Select(x => new
        {
            x.EventName,
            x.Description,
            x.Score,
            x.FileName
        })
        .ToList();


        return Ok(achievementsList);
    }

    [HttpGet("[action]"), Authorize]
    //TODO Вырезать картинки, вынести в дрйгой метод, возвращать Id реквеста, для модификации\удаления
    public IActionResult GetRequests()
    {
        var loginClaim = HttpContext.User.FindFirst(c => c.Type == "Login");
        if (loginClaim is null)
            return BadRequest("User not authenticated");

        var login = loginClaim.Value;

        var requestsList = _db.VerificationRequests
        .Join(
            _db.Users,
            verificationRequest => verificationRequest.OwnerLogin,
            user => user.Login,
            (verificationRequest, user) => new { verificationRequest, user }
        )
        .Join(
            _db.Images,
            vrUser => vrUser.verificationRequest.Id,
            image => image.RequestId,
            (vrUser, image) => new { vrUser.verificationRequest, vrUser.user, image }
        )
        .Where(vrUserImage => vrUserImage.user.Login == login && vrUserImage.verificationRequest.IsOpen)
        .Select(vrUserImage => new
        {
            vrUserImage.verificationRequest.EventName,
            vrUserImage.verificationRequest.Description,
            vrUserImage.image.FileName
        })
        .ToList();


        return Ok(requestsList);
    }

    [HttpPost("[action]")]
    [Authorize]
    public IActionResult NewRequest([FromBody] NewRequest request)
    {
        var login = HttpContext.User.FindFirst(c => c.Type == "Login")?.Value;
        if (login is null) return BadRequest("User not authenticated");

        if (request.ImageNames.Any(img => !_imageService.Validate(img)))
            return BadRequest("Invalid images!!!");

        VerificationRequest newReq = new()
        {
            Id = Guid.NewGuid(),
            OwnerLogin = login,
            EventName = request.Name,
            Description = request.Description
        };

        _db.Add(newReq);

        foreach (string name in request.ImageNames)
            _db.Images.Add(new Image()
            {
                FileName = name,
                RequestId = newReq.Id
            });

        _db.SaveChanges();
        return Ok(newReq.Id);
    }
}