using LifeBalance.Application.Workouts.Models;
using LifeBalance.Domain.Entities;

namespace LifeBalance.Application.Services.Abstractions;

public interface IWorkoutLocalizationService
{
    WorkoutDto Localize(Workout workout);
}