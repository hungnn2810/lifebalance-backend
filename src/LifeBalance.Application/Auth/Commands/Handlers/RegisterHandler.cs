using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Models;
using MediatR;

namespace LifeBalance.Application.Auth.Commands.Handlers;

public class RegisterHandler(IAuthService service) : IRequestHandler<RegisterCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        return await service.RegisterAsync(request);
    }
}