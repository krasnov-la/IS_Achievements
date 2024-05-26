using System.ComponentModel.DataAnnotations;
using Auth;

namespace DataAccess.Models;

public class User
{
    [MaxLength(256)]
    public string Login { get; set; } = null!;
    [MaxLength(256)]
    public string? Nickname { get; set; }
    public string Role { get; set; } = Roles.Default;
    public string HashedPassword { get; set; } = null!;
}