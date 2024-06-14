namespace DataAccess.Models;

public record ActivityRequest
{
    public string Name { get; set; } = null!;
    public DateTime DateTime { get; set; }
    public string Link { get; set; } = null!;
}