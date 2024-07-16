using DataAccess;
using DataAccess.Models;

namespace Services;

public class UnitOfWork : IUnitOfWork
{
    AppDbContext _db;

    public UnitOfWork(AppDbContext db)
    {
        _db = db;
        Achievements = new GenericRepository<Achievement>(_db);
        Activities = new GenericRepository<Activity>(_db);
        Comments = new GenericRepository<Comment>(_db);
        Images = new GenericRepository<Image>(_db);
        Users = new GenericRepository<User>(_db);
        Requests = new GenericRepository<VerificationRequest>(_db);
    }
    public IRepository<Achievement> Achievements { get; private set; }

    public IRepository<Activity> Activities { get; private set; }

    public IRepository<Comment> Comments { get; private set; }

    public IRepository<Image> Images { get; private set; }

    public IRepository<User> Users { get; private set; }

    public IRepository<VerificationRequest> Requests { get; private set; }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}