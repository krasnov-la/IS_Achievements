using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Controllers;
[ApiController]
[Route("[controller]")]
public class RatingController(IUnitOfWork unit) : ControllerBase
{
    IUnitOfWork _unit = unit;

    /// <summary>
    /// Retrieves personal rating information for the authenticated user.
    /// </summary>
    /// <response code="200">Returns the personal rating information.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <remarks>
    /// This method retrieves the rating information for the authenticated user.
    /// This method can be accessed by authorized users.
    ///
    /// **Example request:**
    /// ```
    /// GET /Rating/personal
    /// ```
    /// 
    /// **Example response:**
    /// ```json
    /// {
    ///     "nickname": "JohnDoe",
    ///     "score": 150.5,
    ///     "place": 3
    /// }
    /// ```
    /// </remarks>
    [HttpGet("personal")]
    [Authorize]
    public async Task<IActionResult> GetInfo()
    {
        var login = HttpContext.User.Claims.First(c => c.Type == "Login").Value;

        var data =
            (await _unit.Achievements
            .GetQueryable()
            .Include(a => a.Request)
            .ThenInclude(r => r.Owner)
            .Select(a => new
            {
                a.Request.Owner.Login,
                a.Request.Owner.Nickname,
                a.Score
            })
            .GroupBy(
                u => new { u.Login, u.Nickname },
                (key, group) => new
                {
                    key.Login,
                    key.Nickname,
                    Sum = group.Sum(x => x.Score)
                })
            .OrderByDescending(x => x.Sum)
            .ToListAsync())
            .Select((elem, ind) => new
            {
                Place = ind + 1,
                elem.Login,
                elem.Nickname,
                elem.Sum
            })
            .Where(x => x.Login == login)
            .Select(x => new
            {
                x.Nickname,
                Score = x.Sum,
                x.Place
            })
            .FirstOrDefault();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        data ??= new
        {
            (await _unit.Users.GetById(login)).Nickname,
            Score = 0f,
            Place = 0
        };
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        return Ok(new
        {
            data.Nickname,
            data.Score,
            data.Place
        });
    }

    /// <summary>
    /// Retrieves the scoreboard data with pagination.
    /// </summary>
    /// <param name="count">The number of entries to retrieve.</param>
    /// <param name="offset">The offset from which to start retrieving entries.</param>
    /// <response code="200">Returns the scoreboard data.</response>
    /// <remarks>
    /// This method retrieves the scoreboard data with the specified pagination parameters.
    ///
    /// **Example request:**
    /// ```
    /// GET /Rating/scoreboard/10/0
    /// ```
    /// 
    /// **Example response:**
    /// ```json
    /// [
    ///     {
    ///         "place": 1,
    ///         "nick": "JaneDoe",
    ///         "score": 200.0
    ///     },
    ///     {
    ///         "place": 2,
    ///         "nick": "JohnDoe",
    ///         "score": 150.5
    ///     },
    ///     ...
    /// ]
    /// ```
    /// </remarks>

    [HttpGet("scoreboard/{count}/{offset}")]
    public async Task<IActionResult> GetData(int count, int offset)
    {
        var data =
            (await _unit.Achievements
            .GetQueryable()
            .Include(a => a.Request)
            .ThenInclude(r => r.Owner)
            .Select(a => new
            {
                a.Request.Owner.Login,
                a.Request.Owner.Nickname,
                a.Score
            })
            .GroupBy(
                u => new { u.Login, u.Nickname },
                (key, group) => new
                {
                    key.Login,
                    key.Nickname,
                    Sum = group.Sum(x => x.Score)
                })
            .OrderByDescending(x => x.Sum)
            .Skip(offset)
            .Take(count)
            .ToListAsync())
            .Select((elem, ind) => new
            {
                Place = ind + 1,
                Nick = elem.Nickname,
                Score = elem.Sum
            });

        return Ok(data);
    }
}