using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Models;
using MediatR;

namespace LifeBalance.Application.Auth.Commands.Handlers;

public class RegisterUserHandler(IAuthService service) : IRequestHandler<RegisterUser, BaseResponse>
{
    public async Task<BaseResponse> Handle(RegisterUser request, CancellationToken cancellationToken)
    {
        return await service.RegisterAsync(request);
    }
}