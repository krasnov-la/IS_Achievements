namespace DataAccess.Models;

public record ActivityRequest
{
    public string Name {get; set;}
    public DateTime DateTime {get; set;}
    public string Link {get; set;}
}