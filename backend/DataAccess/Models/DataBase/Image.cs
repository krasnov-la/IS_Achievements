using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public class Image
{
    public Guid Id { get; set; }
    public Guid RequestId { get; set; }

    //EF Navigation
    public VerificationRequest Request {get; set;} = null!;
}