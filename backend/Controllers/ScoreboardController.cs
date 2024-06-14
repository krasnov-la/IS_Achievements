using DataAccess;
using Microsoft.AspNetCore.Mvc;


namespace Controllers;

[Route("[controller]")]
[ApiController]
public class ScoreboardController(AppDbContext dbContext) : ControllerBase
{
    AppDbContext _db = dbContext;

    [HttpGet("[action]/{count}/{offset}")]
    public IActionResult GetData(int count, int offset)
    {
        var scoreboardData = _db.VerificationRequests
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
                key.Login,
                Nick = key.Nickname,
                Score = group.Sum(x => x.Score)
            }
        )
        .OrderByDescending(x => x.Score)
        .ToList()
        .Select((x, index) => new
        {
            Place = index + 1,
            x.Nick,
            x.Score
        })
        .Skip(offset)
        .Take(count)
        .ToList();

        return Ok(scoreboardData);
    }
}