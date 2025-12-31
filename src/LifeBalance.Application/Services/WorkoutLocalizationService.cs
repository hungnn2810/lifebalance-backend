using System.Globalization;
using System.Reflection;
using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Abstractions;
using LifeBalance.Application.Workouts.Models;
using LifeBalance.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace LifeBalance.Application.Services;

public class WorkoutLocalizationService : IWorkoutLocalizationService
{
    private readonly IStringLocalizer _localizer;

    public WorkoutLocalizationService(IStringLocalizerFactory factory, IUserContext userContext)
    {
        var culture = new CultureInfo(userContext.Language ?? "en");
        CultureInfo.CurrentUICulture = culture;

        var location = Assembly.GetExecutingAssembly().GetName().Name;
        if (location != null) _localizer = factory.Create("Workouts", location);
    }

    public WorkoutDto Localize(Workout workout)
    {
        var code = workout.Code;

        return new WorkoutDto
        {
            Id = workout.Id,
            Code = code,
            Type = workout.Type,
            EstimatedCalories = workout.EstimatedCalories,
            Index = workout.Index,
            Name = _localizer[$"Workout.{code}.Name"],
            Title = _localizer[$"Workout.{code}.Title"],
            Notes = _localizer[$"Workout.{code}.Notes"],
            Benefits = _localizer[$"Workout.{code}.Benefits"]
                .Value.Split('|', StringSplitOptions.RemoveEmptyEntries),

            Steps = workout.Steps?
                    .OrderBy(x => x.Index)
                    .Select(step => new WorkoutStepDto
                    {
                        Index = step.Index,
                        Title = _localizer[$"Workout.{code}.Step.{step.Code}.Title"],
                        Description = _localizer[$"Workout.{code}.Step.{step.Code}.Description"]
                    })
                    .ToArray()
                ?? []
        };
    }
}