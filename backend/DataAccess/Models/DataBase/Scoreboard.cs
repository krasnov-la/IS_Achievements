namespace DataAccess.Models;

public class Scoreboard
{
    public int place { get; set; }
    public Guid user_guid { get; set; }
    public decimal score { get; set; }
}

