using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;


namespace Controllers;

[Route("[controller]")]
[ApiController]
public class ScoreboardController(AppDbContext dbContext, IUnitOfWork unit) : ControllerBase
{
    AppDbContext _db = dbContext;
    IUnitOfWork _unit = unit;

    [HttpGet("[action]/{count}/{offset}")]
    public async Task<IActionResult> GetData(int count, int offset)
    {
        var data = 
            (await _unit.Achievements
            .GetQuerable()
            .Include(a => a.Request)
            .ThenInclude(r => r.Owner)
            .Select(a => new{
                a.Request.Owner.Login,
                a.Request.Owner.Nickname,
                a.Score})
            .GroupBy(
                u => new{u.Login, u.Nickname},
                (key, group) => new{
                    key.Login,
                    key.Nickname,
                    Sum = group.Sum(x => x.Score)})
            .OrderByDescending(x => x.Sum)
            .Skip(offset)
            .Take(count)
            .ToListAsync())
            .Select((elem, ind) => new{
                Place = ind + 1,
                Nick = elem.Nickname,
                Score = elem.Sum
            });

        return Ok(data);
    }
}