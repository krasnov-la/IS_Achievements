using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class Activity
{
    public Guid guid { get; init; } = Guid.NewGuid();
    [MaxLength(256)]
    public string name { get; set; } = null!;
    public DateTime datetime { get; set; }
    [MaxLength(2100)]
    public string link { get; set; } = null!;

}