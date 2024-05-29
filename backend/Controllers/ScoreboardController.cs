using DataAccess;
using Microsoft.AspNetCore.Mvc;


namespace Controllers;

[Route("[controller]")]
public class ScoreboardController : ControllerBase
{
    AppDbContext _db;
    public ScoreboardController(AppDbContext dbContext)
    {
        _db = dbContext;
    }

    [HttpGet("[action]/{count}/{offset}")]
    public IActionResult GetData(int count, int offset)
    {
        var scoreboardData = (from verificationRequests in _db.VerificationRequests
                              join achievements in _db.Achievements on verificationRequests.Id equals achievements.RequestId
                              join users in _db.Users on verificationRequests.OwnerLogin equals users.Login
                              group achievements by users.Login into allData
                              select new
                              {
                                  Nick = allData.Key,
                                  Score = allData.Select(x => x.Score).Sum()
                              })
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