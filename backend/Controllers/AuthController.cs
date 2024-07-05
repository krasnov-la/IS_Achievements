using System.Security.Claims;
using Auth;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
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

    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody] CredentialsRequest request)
    {
        if (request.Login is null || request.Login == string.Empty)
            return BadRequest("Empty login");

        if (request.Password is null || request.Password == string.Empty)
            return BadRequest("Empty password");

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

        user.Password = _passwordService.Hash(user, request.Password);
        _unit.Users.Insert(user);
        await _unit.SaveAsync();
        return Ok("User created");
    }

    [HttpPost("[action]")]
    [Authorize(Policy = PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> RegisterAdmin([FromBody] CredentialsRequest request)
    {
        if (request.Login is null || request.Login == string.Empty)
            return BadRequest("Empty login");

        if (request.Password is null)
            return BadRequest("Empty password");

        if (await _unit.Users.GetById(request.Login) is not null)
            return BadRequest("Login taken");

        var user = new User()
        {
            Login = request.Login,
            Nickname = request.Login,
            Refresh = "",
            Role = Roles.Admin,
            RefreshExpire = DateTime.Now,
            Password = ""
        };

        user.Password = _passwordService.Hash(user, request.Password);
        _unit.Users.Insert(user);
        await _unit.SaveAsync();
        return Ok("User created");
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] CredentialsRequest request)
    {
        if (request.Login is null || request.Login == string.Empty)
            return BadRequest("Empty login");

        if (request.Password is null)
            return BadRequest("Empty password");

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

        return Ok(new
        {
            user.Nickname
        });
    }

    [HttpPost("[action]/{new_nick}")]
    [Authorize]
    public async Task<IActionResult> Rename([FromRoute] string new_nick)
    {
        var loginClaim = HttpContext.User.FindFirst(c => c.Type == "Login");
        if (loginClaim == null)
        {
            return BadRequest("User not authenticated");
        }

        var login = loginClaim.Value;
        var user = await _unit.Users.GetById(login);
        if (user is null)
        {
            return BadRequest("User not found");
        }

        user.Nickname = new_nick;
        _unit.Users.Update(user);
        await _unit.SaveAsync();
        return Ok("Nickname changed");

    }
    [HttpPost("[action]")]
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