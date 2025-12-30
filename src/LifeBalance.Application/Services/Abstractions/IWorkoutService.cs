using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Application.Workouts.Commands;
using LifeBalance.Application.Workouts.Models;
using LifeBalance.Application.Workouts.Queries;

namespace LifeBalance.Application.Services.Abstractions;

public interface IWorkoutService
{
    Task<BaseResponse> AddAsync(AddWorkoutCommand command);
    Task<BaseSearchResponse<WorkoutDto>> SearchAsync(SearchWorkoutQuery criteria);
}