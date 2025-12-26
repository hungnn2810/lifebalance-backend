using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.UserTracking.Models;
using MediatR;

namespace LifeBalance.Application.UserTracking.Commands.Handlers;

public class AddUserTrackingHandler(IUserTrackingService service) : IRequestHandler<AddUserTrackingCommand, UserTrackingDto>
{
    public async Task<UserTrackingDto> Handle(AddUserTrackingCommand request, CancellationToken cancellationToken)
    {
        return await service.AddAsync(request);
    }
}