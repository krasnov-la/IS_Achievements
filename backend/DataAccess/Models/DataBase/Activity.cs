using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class Activity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    [MaxLength(256)]
    public string Name { get; set; } = null!;
    public DateTime Datetime { get; set; }
    [MaxLength(2100)]
    public string Link { get; set; } = null!;
    public string AdminLogin {get; set;} = null!;

    //EF Navigaion
    public User Admin {get; set;} = null!;
}