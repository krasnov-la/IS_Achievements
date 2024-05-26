namespace DataAccess;

using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Achievement> Achievements {get; set;}
    public DbSet<Activity> Activities {get; set;}
    public DbSet<Comment> Comments {get; set;}
    public DbSet<Image> Images {get; set;}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}