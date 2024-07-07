using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[PrimaryKey("FileName")]
public class Image
{
    public string FileName { get; set; } = null!;
    public Guid RequestId { get; set; }

    //EF Navigation
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VerificationRequest Request {get; set;} = null!;
}