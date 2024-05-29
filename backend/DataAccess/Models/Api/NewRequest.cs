namespace DataAccess.Models;
public record NewRequest
{
    public string Name {get; set;}
    public string Description {get; set;}
    public IEnumerable<string> ImageNames {get; set;}
}