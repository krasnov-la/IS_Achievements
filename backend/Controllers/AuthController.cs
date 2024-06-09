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

        if (request.Password is null)
            return BadRequest("Empty password");

        if (await _unit.Users.GetById(request.Login) is not null)
            return BadRequest("Login taken");

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

        return Ok(new
        {
            JwtToken = _tokenService.GenerateAccessToken(claims),
            RefreshToken = user.Refresh
        });
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
    {
        var claims = _tokenService.GetPrincipalFromExpToken(request.JwtToken);
        var login = claims.First(c => c.Type == "Login").Value;
        var user = await _unit.Users.GetById(login);
        if (user is null)
            return BadRequest("User nit found");
        if (user.Refresh != request.RefreshToken)
            return BadRequest("Refresh token invalid");

        user.Refresh = _tokenService.GenerateRefreshToken();
        user.RefreshExpire = DateTime.Now.AddDays(5);

        _unit.Users.Update(user);

        await _unit.SaveAsync();

        return Ok(new
        {
            JwtToken = _tokenService.GenerateAccessToken(claims),
            RefreshToken = user.Refresh
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
}