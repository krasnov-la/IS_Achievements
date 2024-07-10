using Auth;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Controllers;

[Route("[controller]")]
[ApiController]
public class RequestsController(IUnitOfWork unit) : ControllerBase
{
    IUnitOfWork _unit = unit;

    [HttpGet("user/{login}")]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> GetRequestsPerUser([FromRoute] string login)
    {
        return Ok(await _unit.Requests
            .GetQuerable()
            .Where(r => r.OwnerLogin == login)
            .OrderBy(r => r.IsOpen)
            .ToListAsync());
    }

    [HttpGet("self")]
    [Authorize]
    public async Task<IActionResult> SelfRequests()
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var login = HttpContext.User.FindFirst(c => c.Type == "Login").Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        return Ok(await _unit.Requests
            .GetQuerable()
            .Where(r => r.OwnerLogin == login)
            .OrderByDescending(r => r.DateTime)
            .ToListAsync());
    }

    [HttpGet("open")]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> GetOpenRequests()
    {
        return Ok(await _unit.Requests
            .GetQuerable()
            .Where(r => r.IsOpen)
            .OrderByDescending(r => r.DateTime)
            .ToListAsync());
    }

    [HttpGet]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _unit.Requests
            .GetQuerable()
            .OrderByDescending(r => r.DateTime)
            .ToListAsync());
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Insert([FromBody] NewRequest request, IImageService imageService)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var login = HttpContext.User.FindFirst(c => c.Type == "Login").Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        if (request.ImageNames.Any(i => !imageService.Validate(i)))
            return BadRequest("Image validation failed.");

        var newReq = new VerificationRequest{
            OwnerLogin = login,
            EventName = request.Name,
            Description = request.Description
        };

        _unit.Requests.Insert(newReq);

        foreach (string imgName in request.ImageNames)
            _unit.Images.Insert(new Image{
                FileName = imgName,
                RequestId = newReq.Id
            });

        await _unit.SaveAsync();

        return Ok();
    }
    //TODO Удаления и обновления не будет!!!(наверное)
}