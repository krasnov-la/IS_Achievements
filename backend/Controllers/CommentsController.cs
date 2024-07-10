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
    readonly IUnitOfWork _unit = unit;

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

    [HttpGet("on-request/{id}")]
    [Authorize]
    public async Task<IActionResult> ReadOnRequest([FromRoute] Guid id)
    {
        var request = await _unit.Requests.GetById(id);
        if (request is null) return NotFound();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var login = HttpContext.User.FindFirst(c => c.Type == "Login").Value;
        var is_admin = Convert.ToBoolean(HttpContext.User.FindFirst(c => c.Type == PolicyData.AdminClaimName).Value);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        if (request.OwnerLogin != login && !is_admin)
            return Unauthorized();

        return Ok(await _unit.Comments
            .GetQuerable()
            .Where(c => c.RequestId == id)
            .OrderByDescending(c => c.Datetime)
            .ToListAsync());
    }

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