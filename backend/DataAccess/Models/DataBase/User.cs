using System.ComponentModel.DataAnnotations;
using Auth;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[PrimaryKey("Login")]
public class User
{
    [MaxLength(256)]
    public string Login { get; set; } = null!;
    [MaxLength(256)]
    public string Nickname { get; set; } = null!;
    public string Role { get; set; } = Roles.Default;
    public string Password { get; set; } = null!;
}