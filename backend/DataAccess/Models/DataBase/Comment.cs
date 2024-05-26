using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class Comment
{
    public Guid guid { get; init; } = Guid.NewGuid();
    public DateTime datetime { get; set; }
    [MaxLength(2000)]
    public string text { get; set; } = null!;
}
