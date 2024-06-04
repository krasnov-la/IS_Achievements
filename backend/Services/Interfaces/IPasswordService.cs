using DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace Services;

public interface IPasswordService
{
    public string Hash(User user, string password);

    public PasswordVerificationResult Validate(User user, string password, string cryptedHash);
}