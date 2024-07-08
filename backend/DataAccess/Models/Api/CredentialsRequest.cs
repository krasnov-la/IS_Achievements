using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;
public record CredentialsRequest
{
    [Required]
    [MinLength(4)]
    public string Login {get; set;} = null!;
    [Required]
    [MinLength(6)]
    public string Password {get; set; } = null!;
}