using Application.Interfaces.Services;
using Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("auth")]
[Produces(typeof(string))]
public class AuthenticationController(IAuthenticationService authenticationService) : ApiController
{
    private readonly IAuthenticationService _authService = authenticationService;
    [HttpGet("login/{oAuth}")]
    public async Task<IActionResult> Login(string oAuth)
    {
        return ResultToResponse(await _authService.Login(oAuth), 
            d => new AuthenticationResponse(
                d.Email,
                d.AccessToken
            ));
    }
}