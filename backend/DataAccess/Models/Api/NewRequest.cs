namespace DataAccess.Models;
public record NewRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public required IEnumerable<string> ImageNames { get; set; }
}