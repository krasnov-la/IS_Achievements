using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;
public record ChangePasswordRequest
{
    [Required]
    [MinLength(6)]
    public string OldPassword {get; set;} = null!;

    [Required]
    [MinLength(6)]
    public string NewPassword {get; set;} = null!;
}