using System.Security.Claims;

namespace Application.Services;

public abstract class ServiceBase
{
    public static string ExtractEmail(ClaimsPrincipal user) 
        => user.FindFirstValue(ClaimTypes.Email) ?? throw new ArgumentException("ClaimsPricipal should contain email claim");
}