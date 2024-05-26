using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class Comment
{
    public Guid Guid { get; init; } = Guid.NewGuid();
    public DateTime Datetime { get; set; }
    [MaxLength(2000)]
    public string Text { get; set; } = null!;
    public Guid RequestGuid {get; set;} 
}
