using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
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
    [MaxLength(128)]
    public string Role { get; set; } = Roles.Default;
    [MaxLength(64)]
    [JsonIgnore]
    public string Refresh {get; set;} = null!;
    [JsonIgnore]
    public DateTime RefreshExpire {get; set;}
    [JsonIgnore]
    [MaxLength(128)]
    public string Password { get; set; } = null!;
}