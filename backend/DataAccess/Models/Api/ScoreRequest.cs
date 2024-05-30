namespace DataAccess.Models;

public record ScoreRequest
{
    public Guid ReqId {get; set;}
    public float Score {get; set;}
}