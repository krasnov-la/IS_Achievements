using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class Achievement
{
    public Guid Guid { get; init; } = Guid.NewGuid();
    public int Score { get; set; }
    public DateTime VerificationDatetime { get; set; }
    public Guid RequestGuid { get; set; }
    [MaxLength(256)]
    public string AdminLogin { get; set; } = null!;
    public string OwnerLogin {get; set;} = null!;
}