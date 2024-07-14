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

    /// <summary>
    /// Retrieves all users.
    /// </summary>
    /// <response code="200">Returns the list of all users.</response>
    /// <remarks>
    /// This method retrieves a list of all users.
    /// This method can only be accessed by users with the "Admin" role.
    /// 
    /// **Example request:**
    /// ```
    /// GET /Users
    /// ```
    /// **Example response:**
    /// ```json
    /// [
    ///     {
    ///         "login": "johndoe",
    ///         "nickname": "John",
    ///         "role": "Default"
    ///     },
    ///     ...
    /// ]
    /// ```
    /// </remarks>
    [HttpGet]
    [Authorize(PolicyData.AdminOnlyPolicyName)]
    public async Task<IActionResult> AllUsers()
    {
        return Ok(await _unit.Users.GetQuerable().OrderBy(u => u.Login).ToListAsync());
    }

    /// <summary>
    /// Retrieves all students (non-admin users).
    /// </summary>
    /// <response code="200">Returns the list of all students.</response>
    /// <remarks>
    /// This method retrieves a list of all users.
    /// This method can only be accessed by users with the "Admin" role.
    /// 
    /// **Example request:**
    /// ```
    /// GET /Users
    /// ```
    /// **Example response:**
    /// ```json
    /// [
    ///     {
    ///         "login": "johndoe",
    ///         "nickname": "John",
    ///         "role": "Default"
    ///     },
    ///     ...
    /// ]
    /// ```
    /// </remarks>
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

    /// <summary>
    /// Retrieves all admin users.
    /// </summary>
    /// <response code="200">Returns the list of all admins.</response>
    /// <remarks>
    /// This method retrieves a list of all admin users.
    /// This method can only be accessed by users with the "Admin" role.
    /// 
    /// **Example request:**
    /// ```
    /// GET /Users/admins
    /// ```
    /// **Example response:**
    /// ```json
    /// [
    ///     {
    ///         "login": "admin1",
    ///         "nickname": "Admin One",
    ///         "role": "Admin"
    ///     },
    ///     ...
    /// ]
    /// ```
    /// </remarks>
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

    /// <summary>
    /// Retrieves a user by their login.
    /// </summary>
    /// <param name="login">The login of the user.</param>
    /// <response code="200">Returns the user details.</response>
    /// <response code="404">User not found.</response>
    /// <remarks>
    /// This method retrieves a user by their login.
    /// 
    /// **Example request:**
    /// ```
    /// GET /Users/johndoe
    /// ```
    /// **Example response:**
    /// ```json
    /// {
    ///     "login": "johndoe",
    ///     "nickname": "John",
    ///     "role": "Default"
    /// }
    /// ```
    /// </remarks>
    [HttpGet("{login}")]
    // TODO: не отправлять role(под вопросом)
    public async Task<IActionResult> GetByLogin([FromRoute] string login)
    {
        var user = await _unit.Users.GetById(login);
        if (user is null) return NotFound();
        return Ok(user);
    }

    /// <summary>
    /// Creates a new student user.
    /// </summary>
    /// <param name="request">The credentials request containing login and password.</param>
    /// <param name="passwordService">The password service for hashing passwords.</param>
    /// <response code="200">User created successfully.</response>
    /// <response code="400">Login already taken.</response>
    /// <remarks>
    /// This method creates a new student user.
    /// 
    /// **Example request:**
    /// ```
    /// POST /Users/students
    /// {
    ///     "Login": "johndoe",
    ///     "Password": "password123"
    /// }
    /// ```
    /// </remarks>
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

    /// <summary>
    /// Creates a new admin user.
    /// </summary>
    /// <param name="request">The credentials request containing login and password.</param>
    /// <param name="passwordService">The password service for hashing passwords.</param>
    /// <response code="200">User created successfully.</response>
    /// <response code="400">Login already taken.</response>
    /// <remarks>
    /// This method creates a new admin user.
    /// This method can only be accessed by users with the "Admin" role.
    /// 
    /// **Example request:**
    /// ```
    /// POST /Users/admins
    /// {
    ///     "Login": "adminuser",
    ///     "Password": "adminpassword"
    /// }
    /// ```
    /// </remarks>
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

    /// <summary>
    /// Changes the password for a specific user.
    /// </summary>
    /// <param name="login">The login of the user.</param>
    /// <param name="request">The change password request containing old and new passwords.</param>
    /// <param name="passwordService">The password service for validating and hashing passwords.</param>
    /// <response code="200">Password changed successfully.</response>
    /// <response code="400">Old password validation failed.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="404">User not found.</response>
    /// <remarks>
    /// This method changes the password for a specific user.
    /// This method can be accessed by users with the "Admin" role or Authorized user.
    /// 
    /// **Example request:**
    /// ```
    /// PATCH /Users/johndoe/password
    /// {
    ///     "OldPassword": "oldpassword",
    ///     "NewPassword": "newpassword"
    /// }
    /// ```
    /// </remarks>
    [HttpPatch("{login}/password")]
    [Authorize]
    public async Task<IActionResult> ChangePassword(
        [FromRoute] string login,
        [FromBody] ChangePasswordRequest request,
        [FromServices] IPasswordService passwordService)
    {
        var login_claim = HttpContext.User.Claims.First(c => c.Type == "Login").Value;
        var is_admin = Convert.ToBoolean(HttpContext.User.Claims.First(c => c.Type == PolicyData.AdminClaimName).Value);
        if (login_claim != login && !is_admin)
            return Forbid();

        var user = await _unit.Users.GetById(login);
        if (user is null) return NotFound("User not found");

        if (passwordService.Validate(user, request.OldPassword, user.Password) == PasswordVerificationResult.Failed)
            return BadRequest("Old password validation failed");

        user.Password = passwordService.Hash(user, request.NewPassword);
        _unit.Users.Update(user);

        await _unit.SaveAsync();

        return Ok();
    }

    /// <summary>
    /// Changes the nickname for a specific user.
    /// </summary>
    /// <param name="login">The login of the user.</param>
    /// <param name="request">The change nickname request containing the new nickname and password.</param>
    /// <param name="passwordService">The password service for validating passwords.</param>
    /// <response code="200">Nickname changed successfully.</response>
    /// <response code="400">Password validation failed.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="404">User not found.</response>
    /// <remarks>
    /// This method changes the nickname for a specific user.
    /// This method can be accessed by users with the "Admin" role or Authorized user.
    /// 
    /// **Example request:**
    /// ```
    /// PATCH /Users/johndoe/nickname
    /// {
    ///     "Password": "password123",
    ///     "NewNick": "newnickname"
    /// }
    /// ```
    /// </remarks>
    [HttpPatch("{login}/nickname")]
    [Authorize]
    public async Task<IActionResult> ChangeNickname(
        [FromRoute] string login,
        [FromBody] ChangeNicknameRequest request,
        [FromServices] IPasswordService passwordService)
    {
        var login_claim = HttpContext.User.Claims.First(c => c.Type == "Login").Value;
        var is_admin = Convert.ToBoolean(HttpContext.User.Claims.First(c => c.Type == PolicyData.AdminClaimName).Value);
        if (login_claim != login && !is_admin)
            return Forbid();

        var user = await _unit.Users.GetById(login);
        if (user is null) return NotFound("User not found");

        if (passwordService.Validate(user, request.Password, user.Password) == PasswordVerificationResult.Failed)
            return BadRequest("Password validation failed");

        user.Nickname = request.NewNick;
        _unit.Users.Update(user);

        await _unit.SaveAsync();

        return Ok();
    }

    /// <summary>
    /// Updates the profile picture for a specific user.
    /// </summary>
    /// <param name="login">The login of the user.</param>
    /// <param name="imageName">The name of the new profile picture.</param>
    /// <param name="imageService">The image service for validating image names.</param>
    /// <response code="200">Profile picture updated successfully.</response>
    /// <response code="400">Invalid image name.</response>
    /// <response code="403">Forbidden.</response>
    /// <response code="404">User not found.</response>
    /// <remarks>
    /// This method updates the profile picture for a specific user.
    /// This method can only be accessed by the user themselves.
    /// 
    /// **Example request:**
    /// ```
    /// PATCH /Users/johndoe/profile-picture/new_profile_picture.jpg
    /// ```
    /// </remarks>

    [HttpPatch("{login}/profile-picture/{imageName}")]
    [Authorize]
    public async Task<IActionResult> UpdatePicture(
        [FromRoute] string login,
        [FromRoute] string imageName,
        [FromServices] IImageService imageService)
    {
        var login_claim = HttpContext.User.Claims.First(c => c.Type == "Login").Value;
        if (login_claim != login)
            return Forbid();

        var user = await _unit.Users.GetById(login);
        if (user is null) 
            return NotFound("User not found");

        if (!imageService.Validate(imageName))
            return BadRequest("Invalid image name");

        user.AvatarImage = imageName;
        await _unit.SaveAsync();

        return Ok();
    }

    //TODO: Delete?
}