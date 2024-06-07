using DataAccess.Models;

namespace Services;

public interface IUnitOfWork
{
    IRepository<Achievement> Achievements {get; }
    IRepository<Activity> Activities {get; }
    IRepository<Comment> Comments {get; }
    IRepository<Image> Images {get; }
    IRepository<User> Users {get; }
    IRepository<VerificationRequest> Requests {get; }
    Task SaveAsync();
}