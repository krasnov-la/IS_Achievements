using Auth;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers;

[Route("controller")]
[ApiController]
public class RequestsController(IUnitOfWork unit) : ControllerBase
{
    IUnitOfWork _unit = unit;

    [HttpGet("user/{login}")]
    //TODO: Set additional authorization rules
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> GetRequestsPerUser([FromRoute] string login)
    {
        return Ok(await _unit.Requests.Get(filter: r => r.OwnerLogin == login, orderBy: r => r.IsOpen));
    }

    [HttpGet("open")]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> GetOpenRequests()
    {
        return Ok(await _unit.Requests.Get(filter: r => r.IsOpen, orderBy: r => r.DateTime));
    }

    [HttpGet]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _unit.Requests.Get(orderBy: r => r.DateTime));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Insert([FromBody] NewRequest request, IImageService imageService)
    {
        var login = HttpContext.User.FindFirst(c => c.Type == "Login").Value;

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