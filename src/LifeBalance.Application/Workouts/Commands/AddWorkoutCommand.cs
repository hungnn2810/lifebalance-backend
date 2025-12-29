using System.Linq.Expressions;
using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Domain.Entities;
using LifeBalance.Domain.Enums;
using MediatR;

namespace LifeBalance.Application.Workouts.Commands;

public class AddWorkoutCommand : IRequest<BaseResponse>
{
    public string Name { get; set; }
    public string Title { get; set; }
    public WorkoutType Type { get; set; }
    public string Notes { get; set; }
    public WorkoutBenefit[] Benefits { get; set; }
    public int EstimatedCalories { get; set; }

    private static Expression<Func<AddWorkoutCommand, Workout>> Projection
    {
        get
        {
            return command => new Workout
            {
                Name = command.Name,
                Title = command.Title,
                Type = command.Type,
                Notes = command.Notes,
                BenefitsEnums = command.Benefits,
                EstimatedCalories = command.EstimatedCalories,
            };
        }
    }
    
    public static Workout Create(AddWorkoutCommand command)
    {
        return command != null ? Projection.Compile().Invoke(command) : null;
    }
}