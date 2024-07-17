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
    /// This method can only be accessed by users with the "Admin" role.
    /// 
    /// **Example request:**
    /// ```
    /// GET /Requests/user/johndoe
    /// ```
    /// **Example response:**
    /// ```json
    /// [
    ///     {
    ///         "Id": "d290f1ee-6c54-4b01-90e6-d701748f0851",
    ///         "OwnerLogin": "johndoe",
    ///         "EventName": "Sample Event",
    ///         "Description": "This is a sample description.",
    ///         "DateTime": "2023-07-10T14:58:00",
    ///         "IsOpen": true,
    ///         "Images": ["image1.jpg", "image2.jpg"]
    ///     },
    ///     ...
    /// ]
    /// ```
    /// </remarks>
    [HttpGet("user/{login}")]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> GetRequestsPerUser([FromRoute] string login)
    {
        return Ok(await _unit.Requests
            .GetQueryable()
            .Include(r => r.Images)
            .Where(r => r.OwnerLogin == login)
            .OrderBy(r => r.Status)
            .Select(r => new
            {
                r.Id,
                r.OwnerLogin,
                r.EventName,
                r.Description,
                r.DateTime,
                Status = Convert.ToString(r.Status),
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
    /// This method can be accessed by authorized users.
    /// 
    /// **Example request:**
    /// ```
    /// GET /Requests/self
    /// ```
    /// **Example response:**
    /// ```json
    /// [
    ///     {
    ///         "Id": "d290f1ee-6c54-4b01-90e6-d701748f0851",
    ///         "OwnerLogin": "johndoe",
    ///         "EventName": "Sample Event",
    ///         "Description": "This is a sample description.",
    ///         "DateTime": "2023-07-10T14:58:00",
    ///         "IsOpen": true,
    ///         "Images": ["image1.jpg", "image2.jpg"]
    ///     },
    ///     ...
    /// ]
    /// ```
    /// </remarks>
    [HttpGet("self")]
    [Authorize]
    public async Task<IActionResult> SelfRequests()
    {
        var login = HttpContext.User.Claims.First(c => c.Type == "Login").Value;

        return Ok(await _unit.Requests
            .GetQueryable()
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
                Status = Convert.ToString(r.Status),
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
    /// This method can only be accessed by users with the "Admin" role.
    /// 
    /// **Example request:**
    /// ```
    /// GET /Requests/open
    /// ```
    /// **Example response:**
    /// ```json
    /// [
    ///     {
    ///         "Id": "d290f1ee-6c54-4b01-90e6-d701748f0851",
    ///         "OwnerLogin": "johndoe",
    ///         "EventName": "Sample Event",
    ///         "Description": "This is a sample description.",
    ///         "DateTime": "2023-07-10T14:58:00",
    ///         "IsOpen": true,
    ///         "Images": ["image1.jpg", "image2.jpg"]
    ///     },
    ///     ...
    /// ]
    /// ```
    /// </remarks>
    [HttpGet("open")]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> GetOpenRequests()
    {
        return Ok(await _unit.Requests
            .GetQueryable()
            .Include(r => r.Images)
            .Where(r => r.Status == RequestStatus.InProgress)
            .OrderByDescending(r => r.DateTime)
            .Select(r => new
            {
                r.Id,
                r.OwnerLogin,
                r.EventName,
                r.Description,
                r.DateTime,
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
    /// This method can only be accessed by users with the "Admin" role.
    /// 
    /// **Example request:**
    /// ```
    /// GET /Requests
    /// ```
    /// 
    /// **Example response:**
    /// ```json
    /// [
    ///     {
    ///         "id": "123e4567-e89b-12d3-a456-426614174000",
    ///         "ownerLogin": "johndoe",
    ///         "eventName": "Event 1",
    ///         "description": "Description of Event 1",
    ///         "dateTime": "2024-07-11T12:34:56Z",
    ///         "isOpen": true,
    ///         "images": ["image1.jpg", "image2.jpg"]
    ///     },
    ///     ...
    /// ]
    /// ```
    /// </remarks>
    [HttpGet]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _unit.Requests
            .GetQueryable()
            .Include(r => r.Images)
            .OrderByDescending(r => r.DateTime)
            .Select(r => new
            {
                r.Id,
                r.OwnerLogin,
                r.EventName,
                r.Description,
                r.DateTime,
                Status = Convert.ToString(r.Status),
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
    /// This method can be accessed by authorized users.
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
        var login = HttpContext.User.Claims.First(c => c.Type == "Login").Value;

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

    /// <summary>
    /// Updates the status of a specific verification request.
    /// </summary>
    /// <param name="id">The unique identifier of the request.</param>
    /// <param name="new_status">The new status of the request.</param>
    /// <response code="200">Request status updated successfully.</response>
    /// <response code="404">Request not found.</response>
    /// <remarks>
    /// This method updates the status of a specific verification request.
    /// This method can only be accessed by users with the "Admin" role.
    /// 
    /// **Example request:**
    /// ```
    /// PATCH /Requests/123e4567-e89b-12d3-a456-426614174000/status/InProgress
    /// ```
    /// </remarks>
    [HttpPatch("{id:guid}/status/{new_status}")]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> UpdateStatus([FromRoute] Guid id, [FromRoute] RequestStatus new_status)
    {
        var request = await _unit.Requests.GetById(id);
        if (request is null)
            return NotFound("Request not found");
        request.Status = new_status;
        _unit.Requests.Update(request);
        await _unit.SaveAsync();
        return Ok();
    }

    //TODO Partial update, контроль версий????
    //TODO Удаления не будет!!!(наверное)
}