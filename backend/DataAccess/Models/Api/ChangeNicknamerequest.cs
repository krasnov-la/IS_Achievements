using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;
public record ChangeNicknameRequest
{
    [Required]
    [MinLength(6)]
    public string Password {get; set;} = null!;

    [Required]
    [MinLength(4)]
    public string NewNick {get; set;} = null!;
}