namespace DataAccess.Models;
public record RefreshRequest
{
    public string JwtToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
}