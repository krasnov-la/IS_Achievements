using Auth;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers;

[ApiController]
[Route("Controller")]
[Authorize(Policy = PolicyData.AdminOnlyPolicyName)]
public class CommentsController(IUnitOfWork unit) : ControllerBase
{
    readonly IUnitOfWork _unit = unit;

    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CommentRequest request)
    {
        var verificationReq = await _unit.Requests.GetById(request.ReqId);
        if (verificationReq is null) return BadRequest("Request not found");

        var commId = Guid.NewGuid();

        _unit.Comments.Insert(new Comment(){
            Id = commId,
            Datetime = DateTime.Now,
            Text = request.Text,
            RequestId = request.ReqId
        });

        await _unit.SaveAsync();
        return Ok(commId);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ReadComment([FromRoute] Guid id)
    {
        var comm = await _unit.Comments.GetById(id);
        if (comm is null) return NotFound();
        return Ok(new {
            comm.Id,
            comm.Text,
            comm.Datetime,
            comm.RequestId
        });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateComment([FromBody] CommentUpdateRequest request)
    {
        var comm = await _unit.Comments.GetById(request.CommId);
        if (comm is null) return NotFound();
        comm.Text = request.Text;
        _unit.Comments.Update(comm);
        await _unit.SaveAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(Guid id)
    {
        var comm = await _unit.Comments.GetById(id);
        if (comm is null) return NotFound();
        _unit.Comments.Delete(comm);
        await _unit.SaveAsync();
        return Ok();
    }
}