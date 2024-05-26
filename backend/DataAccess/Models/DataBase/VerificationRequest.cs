using System.ComponentModel.DataAnnotations;

namespace Models;

public class VerificationRequest
{
    public Guid guid { get; init; } = Guid.NewGuid();
    [MaxLength(200)]
    public string event_name { get; set; } = null!;
    [MaxLength(2000)]
    public string description { get; set; } = null!;
    public DateTime date_time { get; set; }
    public bool is_open { get; set; }
}