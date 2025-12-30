using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Application.Workouts.Commands;

namespace LifeBalance.Application.Services.Abstractions;

public interface IWorkoutService
{
    Task<BaseResponse> AddAsync(AddWorkoutCommand command);
}