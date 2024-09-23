using System.Security.Claims;

namespace Application.Commands.Activities;

public record UpdateActivityCommand(
    Guid Id,
    ClaimsPrincipal User,
    string? Name,
    DateTime? StartimgDate,
    DateTime? EndingDate,
    string? Preview,
    string? Link);