using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public User Admin { get; set; } = null!;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VerificationRequest Request { get; set; } = null!;
}