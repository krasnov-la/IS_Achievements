using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class Achievement
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public float Score { get; set; }
    public DateTime VerificationDatetime { get; set; }
    public Guid RequestId { get; set; }
    [MaxLength(256)]
    public string AdminLogin { get; set; } = null!;

    //EF Navigation
    public User Admin { get; set; } = null!;
    public VerificationRequest Request { get; set; } = null!;
}