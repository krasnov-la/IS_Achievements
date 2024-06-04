using DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace Services;

public class PasswordService : IPasswordService
{
    public string Hash(User user, string password)
    {
        var ph = new PasswordHasher<User>();
        return ph.HashPassword(user, password);
    }

    public PasswordVerificationResult Validate(User user, string password, string hash)
    {
        var ph = new PasswordHasher<User>();
        return ph.VerifyHashedPassword(user, hash, password);
    }
}