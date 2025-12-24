using LifeBalance.Application.SharedKernel.Models;
using MediatR;

namespace LifeBalance.Application.Users.Commands;

public class UpdateUser : IRequest<BaseResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
}