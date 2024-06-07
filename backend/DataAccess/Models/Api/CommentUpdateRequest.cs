namespace DataAccess.Models;

public record CommentUpdateRequest
{
    public Guid CommId { get; set; }
    public string Text { get; set; } = null!;
}