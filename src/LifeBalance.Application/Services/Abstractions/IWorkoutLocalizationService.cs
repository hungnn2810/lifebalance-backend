using LifeBalance.Application.Workouts.Models;

namespace LifeBalance.Application.Services.Abstractions;

public interface IWorkoutLocalizationService
{
    WorkoutLocale Get(string code);
}