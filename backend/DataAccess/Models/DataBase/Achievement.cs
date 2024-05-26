using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class Achievement
{
    public Guid guid { get; init; } = Guid.NewGuid();
    public int score { get; set; }
    public DateTime verification_datetime { get; set; }
    public Guid request_guid { get; set; }
    [MaxLength(256)]
    public string admin_login { get; set; } = null!;
}