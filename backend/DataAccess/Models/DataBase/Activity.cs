using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class Activity
{
    public Guid Guid { get; init; } = Guid.NewGuid();

    [MaxLength(256)]
    public string Name { get; set; } = null!;
    public DateTime Datetime { get; set; }
    [MaxLength(2100)]
    public string Link { get; set; } = null!;
}