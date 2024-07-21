namespace DataAccess;

using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Achievement> Achievements { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<VerificationRequest> VerificationRequests { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    //TODO: Delete seeding data before release
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Add your model configurations here
        modelBuilder.Entity<User>().HasKey(u => u.Login);
        modelBuilder.Entity<Achievement>().HasKey(a => a.Id);
        modelBuilder.Entity<Activity>().HasKey(a => a.Id);
        modelBuilder.Entity<Comment>().HasKey(c => c.Id);
        modelBuilder.Entity<Image>().HasKey(i => i.FileName);
        modelBuilder.Entity<VerificationRequest>().HasKey(v => v.Id);
        modelBuilder.Entity<VerificationRequest>()
            .Property(r => r.Status)
            .HasConversion<string>()
            .HasMaxLength(16);

        // Seeding Users
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Login = "admin",
                Nickname = "Administrator",
                Password = "$2a$11$QBOwTM/1G3zIqQBll7vQDel21tMOmMngs20z0bxrVLEqxyY3tHT02",
                Refresh = "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b",
                RefreshExpire = DateTime.UtcNow.AddDays(30),
                Role = "Admin"
            },
            new User
            {
                Login = "user1",
                Nickname = "User One",
                Password = "$2a$11$b63c2UhfmVGeeUWTnHlas.bk32AEQffYtnGdcX.NT0vzlNCLdZZVm",
                Refresh = "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b",
                RefreshExpire = DateTime.UtcNow.AddDays(30),
                Role = "User"
            },
            new User
            {
                Login = "user2",
                Nickname = "User Two",
                Password = "$2a$11$PW7Dapz13EKI/xGqXjK.Y.DJgkGU39nz79UQyUr6bc4I1UNoUJCey",
                Refresh = "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b",
                RefreshExpire = DateTime.UtcNow.AddDays(30),
                Role = "User"
            },
            new User
            {
                Login = "user3",
                Nickname = "User Three",
                Password = "$2a$11$ACFe85jXeKSHr7m3uycOsu4QN9/FbLb/YgTQ/v7UlR22DvoSX5gbW",
                Refresh = "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b",
                RefreshExpire = DateTime.UtcNow.AddDays(30),
                Role = "User"
            }
        );

        // Seeding VerificationRequests
        var requestId1 = Guid.NewGuid();
        var requestId2 = Guid.NewGuid();
        var requestId3 = Guid.NewGuid();
        var requestId4 = Guid.NewGuid();
        modelBuilder.Entity<VerificationRequest>().HasData(
            new VerificationRequest
            {
                Id = requestId1,
                OwnerLogin = "user1",
                DateTime = DateTime.UtcNow,
                Description = "Sample verification request description 1",
                EventName = "Sample Event 1",
                Status = RequestStatus.Approved
            },
            new VerificationRequest
            {
                Id = requestId2,
                OwnerLogin = "user2",
                DateTime = DateTime.UtcNow.AddHours(-2),
                Description = "Sample verification request description 2",
                EventName = "Sample Event 2",
                Status = RequestStatus.Approved
            },
            new VerificationRequest
            {
                Id = requestId3,
                OwnerLogin = "user2",
                DateTime = DateTime.UtcNow.AddHours(-4),
                Description = "Sample verification request description 3",
                EventName = "Sample Event 3",
                Status = RequestStatus.Approved
            },
            new VerificationRequest
            {
                Id = requestId4,
                OwnerLogin = "user3",
                DateTime = DateTime.UtcNow.AddHours(-4),
                Description = "Sample verification request description 4",
                EventName = "Sample Event 4",
                Status = RequestStatus.InProgress
            }
        );

        // Seeding Achievements
        var achievementId1 = Guid.NewGuid();
        var achievementId2 = Guid.NewGuid();
        var achievementId3 = Guid.NewGuid();
        modelBuilder.Entity<Achievement>().HasData(
            new Achievement
            {
                Id = achievementId1,
                AdminLogin = "admin",
                RequestId = requestId1,
                Score = 95.5f,
                VerificationDatetime = DateTime.UtcNow
            },
            new Achievement
            {
                Id = achievementId2,
                AdminLogin = "admin",
                RequestId = requestId2,
                Score = 88.0f,
                VerificationDatetime = DateTime.UtcNow.AddHours(-1)
            },
            new Achievement
            {
                Id = achievementId3,
                AdminLogin = "admin",
                RequestId = requestId3,
                Score = 92.3f,
                VerificationDatetime = DateTime.UtcNow.AddHours(-2)
            }
        );

        // Seeding Activities
        var activityId1 = Guid.NewGuid();
        var activityId2 = Guid.NewGuid();
        var activityId3 = Guid.NewGuid();
        modelBuilder.Entity<Activity>().HasData(
            new Activity
            {
                Id = activityId1,
                AdminLogin = "admin",
                Datetime = DateTime.UtcNow,
                Link = "http://example.com/activity1",
                Name = "Sample Activity 1"
            },
            new Activity
            {
                Id = activityId2,
                AdminLogin = "admin",
                Datetime = DateTime.UtcNow.AddHours(-1),
                Link = "http://example.com/activity2",
                Name = "Sample Activity 2"
            },
            new Activity
            {
                Id = activityId3,
                AdminLogin = "admin",
                Datetime = DateTime.UtcNow.AddHours(-2),
                Link = "http://example.com/activity3",
                Name = "Sample Activity 3"
            }
        );

        // Seeding Comments
        var commentId1 = Guid.NewGuid();
        var commentId2 = Guid.NewGuid();
        var commentId3 = Guid.NewGuid();
        modelBuilder.Entity<Comment>().HasData(
            new Comment
            {
                Id = commentId1,
                RequestId = requestId1,
                Datetime = DateTime.UtcNow,
                Text = "This is a sample comment 1."
            },
            new Comment
            {
                Id = commentId2,
                RequestId = requestId2,
                Datetime = DateTime.UtcNow.AddHours(-1),
                Text = "This is a sample comment 2."
            },
            new Comment
            {
                Id = commentId3,
                RequestId = requestId3,
                Datetime = DateTime.UtcNow.AddHours(-2),
                Text = "This is a sample comment 3."
            }
        );

        // Seeding Images
        var imageId1 = Guid.NewGuid();
        var imageId2 = Guid.NewGuid();
        var imageId3 = Guid.NewGuid();
        var imageId4 = Guid.NewGuid();
        modelBuilder.Entity<Image>().HasData(
            new Image
            {
                FileName = imageId1.ToString(),
                RequestId = requestId1
            },
            new Image
            {
                FileName = imageId2.ToString(),
                RequestId = requestId2
            },
            new Image
            {
                FileName = imageId3.ToString(),
                RequestId = requestId3
            },
            new Image
            {
                FileName = imageId4.ToString(),
                RequestId = requestId4
            }
        );
    }
}