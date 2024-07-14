using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[PrimaryKey("FileName")]
public class Image
{
    [MaxLength(50)]
    public string FileName { get; set; } = null!;
    public Guid RequestId { get; set; }

    //EF Navigation
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public VerificationRequest Request {get; set;} = null!;
}