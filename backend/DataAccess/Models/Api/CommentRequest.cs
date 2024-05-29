namespace DataAccess.Models;

public record CommentRequest
{
    public Guid ReqId {get; set;}
    public string Text {get; set;}
}