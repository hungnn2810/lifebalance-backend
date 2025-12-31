using System.Linq.Expressions;
using LifeBalance.Domain.Entities;

namespace LifeBalance.Application.Workouts.Models;

public class WorkoutStepDto
{
    public string Title { get; set; }
    public short Index { get; set; }
    public string Description { get; set; }
    public WorkoutStepMediaDto[] Medias { get; set; }

    // private static Expression<Func<WorkoutStep, WorkoutStepDto>> Projection
    // {
    //     get
    //     {
    //         return entity => new WorkoutStepDto
    //         {
    //             Title = entity.Title,
    //             Index = entity.Index,
    //             Description = entity.Description,
    //             Medias = entity.Medias != null && entity.Medias.Count > 0
    //                 ? entity.Medias.Select(WorkoutStepMediaDto.Create).ToArray()
    //                 : Array.Empty<WorkoutStepMediaDto>()
    //         };
    //     }
    // }
    //
    // public static WorkoutStepDto Create(WorkoutStep entity)
    // {
    //     return entity != null ? Projection.Compile().Invoke(entity) : null;
    // }
}