namespace DataAccess.Models;
public record CredentialsRequest
{
    public string Login {get; set;} = null!;
    public string Password {get; set; } = null!;
}