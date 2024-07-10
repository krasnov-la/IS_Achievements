using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;
using Services;

namespace Controllers;

[Route("[controller]")]
[ApiController]
public class StudentController(IUnitOfWork unit, IImageService imageService) : ControllerBase
{
    IUnitOfWork _unit = unit;
    IImageService _imageService = imageService;

    [HttpGet("[action]"), Authorize]
    public async Task<IActionResult> GetInfo()
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var login = HttpContext.User.FindFirst(c => c.Type == "Login").Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

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
            .ToListAsync())
            .Select((elem, ind) => new{
                Place = ind + 1,
                elem.Login,
                elem.Nickname,
                elem.Sum})
            .Where(x => x.Login == login)
            .Select(x => new{
                x.Nickname,
                Score = x.Sum,
                x.Place})
            .FirstOrDefault();

        var StudentResponse = new StudentResponse();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        data ??= new {
                (await _unit.Users.GetById(login)).Nickname,
                Score = 0f,
                Place = 0
            };
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        return Ok(new {
            data.Nickname,
            data.Score,
            data.Place
        });
    }
}