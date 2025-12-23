using LifeBalance.Application.SharedKernel.Models;
using MediatR;

namespace LifeBalance.Application.Auth.Commands.Handlers;

public class RegisterUserHandler : IRequestHandler<RegisterUser, BaseResponse>
{
    public async Task<BaseResponse> Handle(RegisterUser request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}