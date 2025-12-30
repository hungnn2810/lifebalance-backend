using System.Linq.Expressions;
using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Domain.Enums;
using MediatR;

namespace LifeBalance.Application.UserInfo.Commands;

public class AddUserInfoCommand : IRequest<BaseResponse>
{
    public string Avatar { get; set; }
    public short Age { get; set; }
    public short Height { get; set; }
    public short Weight { get; set; }
    public Gender Gender { get; set; }
    public FitnessGoal[] FitnessGoals { get; set; }

    private static Expression<Func<AddUserInfoCommand, Domain.Entities.UserInformation>> Projection
    {
        get
        {
            return command => new Domain.Entities.UserInformation
            {
                Avatar = command.Avatar,
                Age = command.Age,
                Height = command.Height,
                Weight = command.Weight,
                Gender =  command.Gender,
                FitnessGoalEnums = command.FitnessGoals
            };
        }
    }

    public static Domain.Entities.UserInformation Create(AddUserInfoCommand command)
    {
        return command != null ? Projection.Compile().Invoke(command) : null;
    }
}