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
public class AuthController : ControllerBase
{
    IPasswordService _passwordService;
    ITokenService _tokenService;
    AppDbContext _db;
    public AuthController(IPasswordService passwordService, ITokenService tokenService, AppDbContext dbContext)
    {
        _passwordService = passwordService;
        _tokenService = tokenService;
        _db = dbContext;
    }

    [HttpPost("[action]")]
    public IActionResult Register([FromBody] CredentialsRequest request)
    {
        if (request.Login is null || request.Login == string.Empty)
            return BadRequest("Empty login");

        if (request.Password is null)
            return BadRequest("Empty password");

        if (_db.Users.Find(request.Login) is not null)
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
        _db.Users.Add(user);
        _db.SaveChanges();
        return Ok("User created");
    }

    [HttpPost("[action]")]
    public IActionResult Login([FromBody] CredentialsRequest request)
    {
        if (request.Login is null || request.Login == string.Empty)
            return BadRequest("Empty login");

        if (request.Password is null)
            return BadRequest("Empty password");

        var user = _db.Users.Find(request.Login);

        if (user is null) return BadRequest("User not found");

        var result = _passwordService.Validate(user, request.Password, user.Password);

        if (result == PasswordVerificationResult.Failed)
            return BadRequest("Password invalid");

        user.Refresh = _tokenService.GenerateRefreshToken();
        user.RefreshExpire = DateTime.Now.AddDays(5);

        _db.Users.Update(user);

        var claims = new List<Claim>(){
            new("Login", request.Login),
            new("Admin", user.Role == Roles.Admin ? "true" : "false")
        };

        _db.SaveChanges();

        return Ok(new
        {
            JwtToken = _tokenService.GenerateAccessToken(claims),
            RefreshToken = user.Refresh
        });
    }

    [HttpPost("[action]")]
    public IActionResult Refresh([FromBody] RefreshRequest request)
    {
        var claims = _tokenService.GetPrincipalFromExpToken(request.JwtToken);
        var login = claims.First(c => c.Type == "Login").Value;
        var user = _db.Users.Find(login);
        if (user is null)
            return BadRequest("User nit found");
        if (user.Refresh != request.RefreshToken)
            return BadRequest("Refresh token invalid");

        user.Refresh = _tokenService.GenerateRefreshToken();
        user.RefreshExpire = DateTime.Now.AddDays(5);

        _db.Users.Update(user);

        _db.SaveChanges();

        return Ok(new
        {
            JwtToken = _tokenService.GenerateAccessToken(claims),
            RefreshToken = user.Refresh
        });
    }

    [HttpPost("[action]/{new_nick}")]
    [Authorize]
    public IActionResult Rename([FromRoute] string new_nick)
    {
        var loginClaim = HttpContext.User.FindFirst(c => c.Type == "Login");
        if (loginClaim == null)
        {
            return BadRequest("User not authenticated");
        }

        var login = loginClaim.Value;
        var user = _db.Users.Find(login);
        if (user is null)
        {
            return BadRequest("User not found");
        }

        user.Nickname = new_nick;
        _db.Update(user);
        _db.SaveChanges();
        return Ok("Nickname changed");
    }
}