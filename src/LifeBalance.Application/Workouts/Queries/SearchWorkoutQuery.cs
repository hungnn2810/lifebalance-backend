using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Application.Workouts.Models;
using LifeBalance.Domain.Enums;
using MediatR;

namespace LifeBalance.Application.Workouts.Queries;

public class SearchWorkoutQuery : IRequest<BaseSearchResponse<WorkoutDto>>
{
    public string Keyword { get; set; }
    public WorkoutType? Type { get; set; }
    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}