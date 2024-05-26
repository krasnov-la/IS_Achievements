using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[PrimaryKey("Place")]
public class Scoreboard
{
    public int Place { get; set; }
    public string Login { get; set; } = null!;
    public string Nickname {get ; set; } = null!;
    public float Score { get; set; }

    //EF Navigation
    public User Student {get ;set;} = null!;
}