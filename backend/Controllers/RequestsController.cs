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

    /// <summary>
    /// Retrieves all requests for a specific user.
    /// </summary>
    /// <param name="login">The login of the user.</param>
    /// <response code="200">Requests retrieved successfully.</response>
    /// <remarks>
    /// This method retrieves all verification requests for a specific user.
    /// 
    /// **Example request:**
    /// ```
    /// GET /Requests/user/johndoe
    /// ```
    /// </remarks>
    [HttpGet("user/{login}")]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> GetRequestsPerUser([FromRoute] string login)
    {
        return Ok(await _unit.Requests
            .GetQuerable()
            .Include(r => r.Images)
            .Where(r => r.OwnerLogin == login)
            .OrderBy(r => r.IsOpen)
            .Select(r => new
            {
                r.Id,
                r.OwnerLogin,
                r.EventName,
                r.Description,
                r.DateTime,
                r.IsOpen,
                Images = r.Images.Select(i => i.FileName)
            })
            .ToListAsync());
    }

    /// <summary>
    /// Retrieves all requests for the authenticated user.
    /// </summary>
    /// <response code="200">Requests retrieved successfully.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <remarks>
    /// This method retrieves all verification requests for the authenticated user.
    /// 
    /// **Example request:**
    /// ```
    /// GET /Requests/self
    /// ```
    /// </remarks>
    [HttpGet("self")]
    [Authorize]
    public async Task<IActionResult> SelfRequests()
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var login = HttpContext.User.FindFirst(c => c.Type == "Login").Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        return Ok(await _unit.Requests
            .GetQuerable()
            .Include(r => r.Images)
            .Where(r => r.OwnerLogin == login)
            .OrderByDescending(r => r.DateTime)
            .Select(r => new
            {
                r.Id,
                r.OwnerLogin,
                r.EventName,
                r.Description,
                r.DateTime,
                r.IsOpen,
                Images = r.Images.Select(i => i.FileName)
            })
            .ToListAsync());
    }

    /// <summary>
    /// Retrieves all open requests.
    /// </summary>
    /// <response code="200">Open requests retrieved successfully.</response>
    /// <remarks>
    /// This method retrieves all open verification requests.
    /// 
    /// **Example request:**
    /// ```
    /// GET /Requests/open
    /// ```
    /// </remarks>
    [HttpGet("open")]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> GetOpenRequests()
    {
        return Ok(await _unit.Requests
            .GetQuerable()
            .Include(r => r.Images)
            .Where(r => r.IsOpen)
            .OrderByDescending(r => r.DateTime)
            .Select(r => new
            {
                r.Id,
                r.OwnerLogin,
                r.EventName,
                r.Description,
                r.DateTime,
                r.IsOpen,
                Images = r.Images.Select(i => i.FileName)
            })
            .ToListAsync());
    }

    /// <summary>
    /// Retrieves all requests.
    /// </summary>
    /// <response code="200">All requests retrieved successfully.</response>
    /// <remarks>
    /// This method retrieves all verification requests.
    /// 
    /// **Example request:**
    /// ```
    /// GET /Requests
    /// ```
    /// </remarks>
    [HttpGet]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _unit.Requests
            .GetQuerable()
            .Include(r => r.Images)
            .OrderByDescending(r => r.DateTime)
            .Select(r => new
            {
                r.Id,
                r.OwnerLogin,
                r.EventName,
                r.Description,
                r.DateTime,
                r.IsOpen,
                Images = r.Images.Select(i => i.FileName)
            })
            .ToListAsync());
    }

    /// <summary>
    /// Inserts a new request.
    /// </summary>
    /// <param name="request">The new request details.</param>
    /// <param name="imageService">The image service for validation.</param>
    /// <response code="200">Request inserted successfully.</response>
    /// <response code="400">Image validation failed.</response>
    /// <remarks>
    /// This method inserts a new verification request.
    /// 
    /// **Example request:**
    /// ```
    /// POST /Requests
    /// {
    ///     "Name": "Sample Event",
    ///     "Description": "This is a sample description.",
    ///     "ImageNames": ["image1.jpg", "image2.jpg"]
    /// }
    /// ```
    /// </remarks>
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Insert([FromBody] NewRequest request, IImageService imageService)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var login = HttpContext.User.FindFirst(c => c.Type == "Login").Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        if (request.ImageNames.Any(i => !imageService.Validate(i)))
            return BadRequest("Image validation failed.");

        var newReq = new VerificationRequest
        {
            OwnerLogin = login,
            EventName = request.Name,
            Description = request.Description
        };

        _unit.Requests.Insert(newReq);

        foreach (string imgName in request.ImageNames)
            _unit.Images.Insert(new Image
            {
                FileName = imgName,
                RequestId = newReq.Id
            });

        await _unit.SaveAsync();

        return Ok();
    }
    //TODO Удаления и обновления не будет!!!(наверное)
}