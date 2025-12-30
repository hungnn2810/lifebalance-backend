using System.Linq.Expressions;
using LifeBalance.Domain.Entities;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Application.Workouts.Models;

public class WorkoutDto
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public WorkoutType Type { get; set; }
    public string Notes { get; set; }
    public string[] Benefits { get; set; }
    public int EstimatedCalories { get; set; }
    public int Index { get; set; }
    public WorkoutStepDto[] Steps { get; set; }

    private static Expression<Func<Workout, WorkoutDto>> Projection
    {
        get
        {
            return entity => new WorkoutDto
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                Title = entity.Title,
                Type = entity.Type,
                Notes = entity.Notes,
                Benefits = entity.Benefits,
                EstimatedCalories = entity.EstimatedCalories,
                Index = entity.Index,
                Steps = entity.Steps != null && entity.Steps.Count > 0
                    ? entity.Steps.OrderBy(x => x.Index).Select(WorkoutStepDto.Create).ToArray()
                    : Array.Empty<WorkoutStepDto>()
            };
        }
    }

    public static WorkoutDto Create(Workout entity)
    {
        return entity != null ? Projection.Compile().Invoke(entity) : null;
    }
}