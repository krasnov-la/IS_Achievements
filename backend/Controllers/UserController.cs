using Auth;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Controllers;
[ApiController]
[Route("[controller]")]
public class UsersController(IUnitOfWork unit) : ControllerBase
{
    readonly IUnitOfWork _unit = unit;

    [HttpGet]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> AllUsers()
    {
        return Ok(await _unit.Users.GetQuerable().OrderBy(u => u.Login).ToListAsync());
    }

    [HttpGet("students")]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> NonAdmins()
    {
        return Ok(await _unit.Users
            .GetQuerable()
            .Where(u => u.Role == Roles.Default)
            .OrderBy(u => u.Login)
            .ToListAsync());
    }

    [HttpGet("admins")]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> Admins()
    {
        return Ok(await _unit.Users
            .GetQuerable()
            .Where(u => u.Role == Roles.Admin)
            .OrderBy(u => u.Login)
            .ToListAsync());
    }

    [HttpGet("{login}")]
    public async Task<IActionResult> GetByLogin([FromRoute] string login)
    {
        var user = await _unit.Users.GetById(login);
        if (user is null) return NotFound();
        return Ok(user);
    }

    [HttpPost("students")]
    public async Task<IActionResult> CreateStudent(
        [FromBody] CredentialsRequest request, 
        [FromServices] IPasswordService passwordService)
    {
        if (await _unit.Users.GetById(request.Login) is not null)
            return BadRequest("Login already taken");

        var user = new User()
        {
            Login = request.Login,
            Nickname = request.Login,
            Refresh = "",
            RefreshExpire = DateTime.Now,
            Password = ""
        };

        user.Password = passwordService.Hash(user, request.Password);
        _unit.Users.Insert(user);
        await _unit.SaveAsync();
        return Ok("User created");
    }

    [HttpPost("admins")]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> CreateAdmin(
        [FromBody] CredentialsRequest request, 
        [FromServices] IPasswordService passwordService)
    {
        if (await _unit.Users.GetById(request.Login) is not null)
            return BadRequest("Login already taken");

        var user = new User()
        {
            Login = request.Login,
            Nickname = request.Login,
            Refresh = "",
            RefreshExpire = DateTime.Now,
            Password = "",
            Role = Roles.Admin
        };

        user.Password = passwordService.Hash(user, request.Password);
        _unit.Users.Insert(user);
        await _unit.SaveAsync();
        return Ok("User created");
    }

    [HttpPatch("{login}/password")]
    public async Task<IActionResult> ChangePassword(
        [FromRoute] string login, 
        [FromBody] ChangePasswordRequest request, 
        [FromServices] IPasswordService passwordService)
    {
        var user = await _unit.Users.GetById(login);
        if (user is null) return NotFound("User not found");

        if (passwordService.Validate(user, request.OldPassword, user.Password) == PasswordVerificationResult.Failed)
            return BadRequest("Old password validation failed");

        user.Password = passwordService.Hash(user, request.NewPassword);
        _unit.Users.Update(user);

        await _unit.SaveAsync();

        return Ok();
    }

    [HttpPatch("{login}/nickname")]
    public async Task<IActionResult> ChangeNickname(
        [FromRoute] string login, 
        [FromBody] ChangeNicknameRequest request, 
        [FromServices] IPasswordService passwordService)
    {
        var user = await _unit.Users.GetById(login);
        if (user is null) return NotFound("User not found");

        if (passwordService.Validate(user, request.Password, user.Password) == PasswordVerificationResult.Failed)
            return BadRequest("Password validation failed");

        user.Nickname = request.NewNick;
        _unit.Users.Update(user);

        await _unit.SaveAsync();

        return Ok();
    }
}