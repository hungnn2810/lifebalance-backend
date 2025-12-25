using System.Linq.Expressions;
using LifeBalance.Application.SharedKernel.Models;
using MediatR;

namespace LifeBalance.Application.UserInfo.Commands;

public class UpdateUserInfoCommand : IRequest<BaseResponse>
{
    public Guid UserId { get; set; }
    public string Avatar { get; set; }
    public short Age { get; set; }
    public short Height { get; set; }
    public short Weight { get; set; }
    public string FitnessGoals { get; set; }

    private static Expression<Func<UpdateUserInfoCommand, Domain.Entities.UserInformation>> Projection
    {
        get
        {
            return command => new Domain.Entities.UserInformation
            {
                Id = command.UserId,
                Avatar = command.Avatar,
                Age = command.Age,
                Height = command.Height,
                Weight = command.Weight,
                FitnessGoals = command.FitnessGoals
            };
        }
    }

    public static Domain.Entities.UserInformation Create(UpdateUserInfoCommand command)
    {
        return command != null ? Projection.Compile().Invoke(command) : null;
    }
}