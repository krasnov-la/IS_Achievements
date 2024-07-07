using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace DataAccess.Models;

public class VerificationRequest
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string OwnerLogin {get; set;} = null!;
    [MaxLength(200)]
    public string EventName { get; set; } = null!;
    [MaxLength(2000)]
    public string Description { get; set; } = null!;
    public DateTime DateTime { get; set; } = DateTime.Now;
    public bool IsOpen { get; set; } = true;

    //EF Navigation
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public User Owner {get; set;} = null!;
}