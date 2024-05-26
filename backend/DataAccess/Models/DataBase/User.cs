using System.ComponentModel.DataAnnotations;
using Auth;

namespace DataAccess.Models;

public class User
{
    public Guid guid { get; init; } = Guid.NewGuid();
    [MaxLength(256)]
    public string login { get; set; } = null!;
    [MaxLength(256)]
    public string? nickname { get; set; }
    public string role { get; set; } = Roles.Default;
    public string hashed_password { get; set; } = null!;
}