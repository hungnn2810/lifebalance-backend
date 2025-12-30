
using System.Linq.Expressions;
using LifeBalance.Domain.Entities;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Application.Workouts.Models;

public class WorkoutStepMediaDto
{
    public MediaType MediaType { get; set; }
    public string ObjectKey { get; set; }
    public string Url { get; set; }
    public int SortOrder { get; set; }

    private static Expression<Func<WorkoutStepMedia, WorkoutStepMediaDto>> Projection
    {
        get
        {
            return entity => new WorkoutStepMediaDto
            {
                MediaType = entity.MediaType,
                ObjectKey = entity.ObjectKey,
                Url = entity.Url,
                SortOrder = entity.SortOrder
            };
        }
    }
    
    public static WorkoutStepMediaDto Create(WorkoutStepMedia entity)
    {
        return entity != null ? Projection.Compile().Invoke(entity) : null;
    }
}