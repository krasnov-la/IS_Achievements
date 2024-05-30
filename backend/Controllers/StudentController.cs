using DataAccess;
using DataAccess.Models;
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
    IImageService _imageService;
    public StudentController(AppDbContext dbContext, IImageService imageService)
    {
        _db = dbContext;
        _imageService = imageService;
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
    //TODO Вырезать картинки, вынести в дрйгой метод, возвращать Id реквеста, для модификации\удаления
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

    [HttpPost("[action]")]
    [Authorize]
    public IActionResult NewRequest([FromBody] NewRequest request)
    {
        var loginClaim = HttpContext.User.FindFirst(c => c.Type == "Login");
        if (loginClaim is null)
            return BadRequest("User not authenticated");

        var login = loginClaim.Value;

        if (request.ImageNames.Any(img => !_imageService.Validate(img)))
            return BadRequest("Invalid images!!!");

        VerificationRequest newReq = new(){
            Id = Guid.NewGuid(),
            OwnerLogin = login,
            EventName = request.Name,
            Description = request.Description
        };

        _db.Add(newReq);

        foreach (string name in request.ImageNames)
        {
            _db.Images.Add(new Image(){
                FileName = name,
                RequestId = newReq.Id
            });
        }

        _db.SaveChanges();

        return Ok(newReq.Id);
    }
}