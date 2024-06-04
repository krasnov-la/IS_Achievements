using DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace Services;

public class BCryptPasswordService : IPasswordService
{
    public string Hash(User user, string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, user.Login);
    }

    public PasswordVerificationResult Validate(User user, string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash)?PasswordVerificationResult.Success:PasswordVerificationResult.Failed;
    }
}