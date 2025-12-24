using System.Linq.Expressions;
using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Domain.Entities;
using MediatR;

namespace LifeBalance.Application.Auth.Commands;

public class RegisterCommand : IRequest<BaseResponse>
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }

    private static Expression<Func<RegisterCommand, User>> Projection
    {
        get
        {
            return command => new User
            {
                Id = Guid.NewGuid(),
                Email = command.Email,
                Name = command.Name
            };
        }
    }

    public static User Create(RegisterCommand command)
    {
        return command != null ? Projection.Compile().Invoke(command) : null;
    }
}