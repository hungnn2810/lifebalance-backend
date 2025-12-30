using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Application.Workouts.Commands;

namespace LifeBalance.Application.Services;

public class WorkoutService : IWorkoutService
{
    public async Task<BaseResponse> AddAsync(AddWorkoutCommand command)
    {
        throw new NotImplementedException();
    }
}