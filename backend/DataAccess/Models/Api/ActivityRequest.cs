using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public record ActivityRequest
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; } = null!;
    [Required]
    [MaxLength(50)]
    public string Preview { get; set; } = null!;
    public DateTime DateTime { get; set; }
    public string Link { get; set; } = null!;
}