using System.ComponentModel.DataAnnotations;

namespace Models;

public class VerificationRequest
{
    public Guid Guid { get; init; } = Guid.NewGuid();
    [MaxLength(200)]
    public string EventName { get; set; } = null!;
    [MaxLength(2000)]
    public string Description { get; set; } = null!;
    public DateTime DateTime { get; set; } = DateTime.Now;
    public bool IsOpen { get; set; } = true;
}