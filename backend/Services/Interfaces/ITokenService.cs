using System.Security.Claims;

namespace Services;

public interface ITokenService
{
    string GenerateAccessToken(IEnumerable<Claim> claims);
    string GenerateRefreshToken();
    IEnumerable<Claim> GetPrincipalFromExpToken(string token);
}