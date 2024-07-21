using System.Security.Claims;
using Auth;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController(IPasswordService passwordService, ITokenService tokenService, IUnitOfWork unit) : ControllerBase
{
    IPasswordService _passwordService = passwordService;
    ITokenService _tokenService = tokenService;
    IUnitOfWork _unit = unit;

    /// <summary>
    /// Handles user login.
    /// </summary>
    /// <param name="request">The login credentials.</param>
    /// <response code="200">Sets authentication cookies.</response>
    /// <response code="400">User not found or Invalid password.</response>
    /// <remarks>
    /// This method validates the user's credentials, generates a refresh token, and sets authentication cookies.
    /// </remarks>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] CredentialsRequest request)
    {
        var user = await _unit.Users.GetById(request.Login);

        if (user is null) return BadRequest("User not found");

        var result = _passwordService.Validate(user, request.Password, user.Password);

        if (result == PasswordVerificationResult.Failed)
            return BadRequest("Password invalid");

        user.Refresh = _tokenService.GenerateRefreshToken();
        user.RefreshExpire = DateTime.Now.AddDays(5);

        _unit.Users.Update(user);

        var claims = new List<Claim>(){
            new("Login", request.Login),
            new("Admin", user.Role == Roles.Admin ? "true" : "false")
        };

        await _unit.SaveAsync();

        HttpContext.Response.Cookies.Append("exp", "somescaryhash", new()
        {
            Expires = DateTime.Now.AddMinutes(10)
        });
        HttpContext.Response.Cookies.Append("cookie-1", _tokenService.GenerateAccessToken(claims));
        HttpContext.Response.Cookies.Append("cookie-2", user.Refresh, new()
        {
            Expires = DateTime.Now.AddDays(5)
        });

        return Ok();
    }

    /// <summary>
    /// Handles user logout.
    /// </summary>
    /// <response code="200">Deletes authentication cookies.</response>
    /// <response code="400">User not authenticated or user not found.</response>
    /// <remarks>
    /// This method deletes the user's refresh token and authentication cookies.
    /// </remarks>
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var login = HttpContext.User.FindFirst(c => c.Type == "Login")?.Value;
        if (login is null) return BadRequest("User not authenticated");
        var user = await _unit.Users.GetById(login);
        if (user is null) return BadRequest("User not found");

        user.Refresh = "";
        user.RefreshExpire = DateTime.Now;

        _unit.Users.Update(user);
        await _unit.SaveAsync();

        HttpContext.Response.Cookies.Delete("exp");
        HttpContext.Response.Cookies.Delete("cookie-1");
        HttpContext.Response.Cookies.Delete("cookie-2");

        return Ok();
    }
}