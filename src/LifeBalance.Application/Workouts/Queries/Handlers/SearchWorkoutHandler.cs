using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Application.Workouts.Models;
using MediatR;

namespace LifeBalance.Application.Workouts.Queries.Handlers;

public class SearchWorkoutHandler(IWorkoutService service) : IRequestHandler<SearchWorkoutQuery, BaseSearchResponse<WorkoutDto>>
{
    public async Task<BaseSearchResponse<WorkoutDto>> Handle(SearchWorkoutQuery request, CancellationToken cancellationToken)
    {
        return await service.SearchAsync(request);
    }
}