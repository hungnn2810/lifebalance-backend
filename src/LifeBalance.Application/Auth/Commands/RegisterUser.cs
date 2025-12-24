using LifeBalance.Application.SharedKernel.Models;
using MediatR;

namespace LifeBalance.Application.Auth.Commands;

public class RegisterUser : IRequest<BaseResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
}