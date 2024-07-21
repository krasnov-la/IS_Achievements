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
    public RequestStatus Status { get; set; } = RequestStatus.InProgress;

    //EF Navigation
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public User Owner {get; set;} = null!;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<Image> Images {get;set;} = null!;
}

public enum RequestStatus
{
    InProgress = 0,
    Rejected = 1,
    Approved = 2
}