public record RefreshRequest
{
    public string JwtToken {get; set; }
    public string RefreshToken {get; set; }
}