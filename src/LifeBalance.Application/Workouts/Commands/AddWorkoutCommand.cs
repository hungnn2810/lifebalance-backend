using System.Linq.Expressions;
using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Application.Workouts.Models;
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
    public string[] Benefits { get; set; }
    public int EstimatedCalories { get; set; }
    public WorkoutStepDto[] Steps { get; set; }

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
                Benefits = command.Benefits,
                EstimatedCalories = command.EstimatedCalories,
                Steps = command.Steps.Select(stepDto => new WorkoutStep
                {
                    Title = stepDto.Title,
                    StepOrder = stepDto.StepOrder,
                    Description = stepDto.Description,
                    Medias = stepDto.Medias.Select(mediaDto => new WorkoutStepMedia
                    {
                        MediaType = mediaDto.MediaType,
                        ObjectKey = mediaDto.ObjectKey,
                        Url = mediaDto.Url,
                        SortOrder = mediaDto.SortOrder
                    }).ToList()
                }).ToList()
            };
        }
    }
    
    public static Workout Create(AddWorkoutCommand command)
    {
        return command != null ? Projection.Compile().Invoke(command) : null;
    }
}