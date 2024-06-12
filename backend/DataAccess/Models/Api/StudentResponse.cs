namespace DataAccess.Models;

public record StudentResponse
{

    public string Nickname { get; set; } = null!;
    public float Score { get; set; }
    public int Place { get; set; }
}
