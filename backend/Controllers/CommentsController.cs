using Auth;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Controllers;

[ApiController]
[Route("[Controller]")]
public class CommentsController(IUnitOfWork unit) : ControllerBase
{
    //TODO: Информация о комментаторе(мб)
    //TODO: Summary изменений в реквесте???
    readonly IUnitOfWork _unit = unit;

    /// <summary>
    /// Creates a new comment on a specific request.
    /// </summary>
    /// <param name="request">The request containing comment details.</param>
    /// <returns>Returns the ID of the created comment.</returns>
    /// <response code="200">Comment created successfully.</response>
    /// <response code="400">Request not found.</response>
    /// <remarks>
    /// This method can only be accessed by users with the "Admin" role.
    ///
    /// **Example request:**
    /// ```
    /// POST /Comments
    /// {
    ///     "ReqId": "d290f1ee-6c54-4b01-90e6-d701748f0851",
    ///     "Text": "This is a sample comment."
    /// }
    /// ```
    /// **Example response:**
    /// ```json
    /// "123e4567-e89b-12d3-a456-426614174000"
    /// ```
    /// </remarks>
    [HttpPost]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> CreateComment([FromBody] CommentRequest request)
    {
        var verificationReq = await _unit.Requests.GetById(request.ReqId);
        if (verificationReq is null) return BadRequest("Request not found");

        var commId = Guid.NewGuid();

        _unit.Comments.Insert(new Comment()
        {
            Id = commId,
            Datetime = DateTime.Now,
            Text = request.Text,
            RequestId = request.ReqId
        });

        await _unit.SaveAsync();
        return Ok(commId);
    }

    /// <summary>
    /// Retrieves comments for a specific request.
    /// </summary>
    /// <param name="id">The ID of the request.</param>
    /// <returns>Returns a list of comments for the specified request.</returns>
    /// <response code="200">Comments retrieved successfully.</response>
    /// <response code="400">Request not found or unauthorized access.</response>
    /// <remarks>
    /// This method can be accessed by authorized users. If the user is not the owner of the request and is not an admin, access is denied.
    ///
    /// **Example request:**
    /// ```
    /// GET /Comments/on-request/d290f1ee-6c54-4b01-90e6-d701748f0851
    /// ```
    /// **Example response:**
    /// ```json
    /// [
    ///     {
    ///         "id": "123e4567-e89b-12d3-a456-426614174000",
    ///         "text": "This is a sample comment.",
    ///         "datetime": "2024-07-11T12:34:56Z",
    ///         "requestId": "d290f1ee-6c54-4b01-90e6-d701748f0851"
    ///     },
    ///     ...
    /// ]
    /// ```
    /// </remarks>
    [HttpGet("on-request/{id}")]
    [Authorize]
    public async Task<IActionResult> ReadOnRequest([FromRoute] Guid id)
    {
        var request = await _unit.Requests.GetById(id);
        if (request is null) return NotFound();
        var login = HttpContext.User.Claims.First(c => c.Type == "Login").Value;
        var is_admin = Convert.ToBoolean(HttpContext.User.Claims.First(c => c.Type == PolicyData.AdminClaimName).Value);

        if (request.OwnerLogin != login && !is_admin)
            return Unauthorized();

        return Ok(await _unit.Comments
            .GetQuerable()
            .Where(c => c.RequestId == id)
            .OrderByDescending(c => c.Datetime)
            .ToListAsync());
    }

    /// <summary>
    /// Retrieves a specific comment by its ID.
    /// </summary>
    /// <param name="id">The ID of the comment.</param>
    /// <returns>Returns the details of the specified comment.</returns>
    /// <response code="200">Comment retrieved successfully.</response>
    /// <response code="404">Comment not found.</response>
    /// <remarks>
    /// This method can be accessed by authorized users.
    ///
    /// **Example request:**
    /// ```
    /// GET /Comments/d290f1ee-6c54-4b01-90e6-d701748f0851
    /// ```
    /// **Example response:**
    /// ```json
    /// {
    ///     "id": "123e4567-e89b-12d3-a456-426614174000",
    ///     "text": "This is a sample comment.",
    ///     "datetime": "2024-07-11T12:34:56Z",
    ///     "requestId": "d290f1ee-6c54-4b01-90e6-d701748f0851"
    /// }
    /// ```
    /// </remarks>
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> ReadComment([FromRoute] Guid id)
    {
        var comm = await _unit.Comments.GetById(id);
        if (comm is null) return NotFound();
        return Ok(new
        {
            comm.Id,
            comm.Text,
            comm.Datetime,
            comm.RequestId
        });
    }

    /// <summary>
    /// Updates a specific comment by its ID.
    /// </summary>
    /// <param name="request">The request containing updated comment details.</param>
    /// <param name="id">The ID of the comment to update.</param>
    /// <returns>Returns a status indicating the result of the update operation.</returns>
    /// <response code="200">Comment updated successfully.</response>
    /// <response code="404">Comment not found.</response>
    /// <remarks>
    /// This method can only be accessed by users with the "Admin" role.
    ///
    /// **Example request:**
    /// ```
    /// PUT /Comments/d290f1ee-6c54-4b01-90e6-d701748f0851
    /// {
    ///     "ReqId": "d290f1ee-6c54-4b01-90e6-d701748f0851",
    ///     "Text": "Updated comment text."
    /// }
    /// ```
    /// </remarks>
    [HttpPut("{id}")]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> UpdateComment([FromBody] CommentRequest request, [FromRoute] Guid id)
    {
        var comm = await _unit.Comments.GetById(id);
        if (comm is null) return NotFound();

        comm.RequestId = request.ReqId;
        comm.Text = request.Text;

        _unit.Comments.Update(comm);
        await _unit.SaveAsync();
        return Ok();
    }

    /// <summary>
    /// Deletes a specific comment by its ID.
    /// </summary>
    /// <param name="id">The ID of the comment to delete.</param>
    /// <returns>Returns a status indicating the result of the delete operation.</returns>
    /// <response code="200">Comment deleted successfully.</response>
    /// <response code="404">Comment not found.</response>
    /// <remarks>
    /// This method can only be accessed by users with the "Admin" role.
    ///
    /// **Example request:**
    /// ```
    /// DELETE /Comments/d290f1ee-6c54-4b01-90e6-d701748f0851
    /// ```
    /// </remarks>
    [HttpDelete("{id}")]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> DeleteComment(Guid id)
    {
        var comm = await _unit.Comments.GetById(id);
        if (comm is null) return NotFound();

        _unit.Comments.Delete(comm);
        await _unit.SaveAsync();
        return Ok();
    }
}