using LifeBalance.Application.SharedKernel.Models;
using MediatR;

namespace LifeBalance.Application.Users.Commands;

public class UpdateUserInformation : IRequest<BaseResponse>
{
    public Guid Id { get; set; }
    public string Password { get; set; }
}