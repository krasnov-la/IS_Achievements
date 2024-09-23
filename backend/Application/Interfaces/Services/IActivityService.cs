using System.Security.Claims;
using Application.Commands.Activities;
using Application.DTO;
using FluentResults;

namespace Application.Interfaces.Services;

public interface IActivityService
{
    Task<Result<ActivityDto>> Create(NewActivityCommand command);
    Task<Result> Delete(Guid id);
    Task<Result<List<ActivityDto>>> GetActivities(GetActivitiesCommand getActivitiesCommand);
    Task<Result<ActivityDto>> GetById(Guid id);
    Task<Result<ActivityDto>> Update(UpdateActivityCommand updateActivityCommand);
}