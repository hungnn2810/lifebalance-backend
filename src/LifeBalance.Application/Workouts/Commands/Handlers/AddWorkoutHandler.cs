using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Models;
using MediatR;

namespace LifeBalance.Application.Workouts.Commands.Handlers;

public class AddWorkoutHandler(IWorkoutService service) : IRequestHandler<AddWorkoutCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(AddWorkoutCommand request, CancellationToken cancellationToken)
    {
        return await service.AddAsync(request);
    }
}