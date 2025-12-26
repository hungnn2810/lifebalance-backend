using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.UserTracking.Models;
using MediatR;

namespace LifeBalance.Application.UserTracking.Queries.Handlers;

public class GetUserTrackingHandler(IUserTrackingService service) : IRequestHandler<GetUserTrackingQuery, UserTrackingDto> 
{
    public async Task<UserTrackingDto> Handle(GetUserTrackingQuery request, CancellationToken cancellationToken)
    {
        return await service.FindAsync(request);
    }
}