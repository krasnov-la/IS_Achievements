namespace DataAccess.Models;

public class Scoreboard
{
    public int Place { get; set; }
    public Guid UserGuid { get; set; }
    public decimal Score { get; set; }
}

