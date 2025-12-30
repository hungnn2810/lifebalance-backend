using System.Linq.Expressions;
using LifeBalance.Domain.Entities;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Application.UserInfo.Models;

public class UserInfoDto
{
    public Guid UserId { get; set; }
    public string Avatar { get; set; }
    public short Age { get; set; }
    public short Weight { get; set; }
    public short Height { get; set; }
    public Gender Gender { get; set; }
    public FitnessGoal[] FitnessGoals { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    private static Expression<Func<UserInformation, UserInfoDto>> Projection
    {
        get
        {
            return entity => new UserInfoDto
            {
                UserId = entity.Id,
                Avatar = entity.Avatar,
                Age = entity.Age,
                Weight = entity.Weight,
                Height = entity.Height,
                Gender = entity.Gender,
                FitnessGoals = entity.FitnessGoalEnums,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
    
    public static UserInfoDto Create(UserInformation entity)
    {
        return entity != null ? Projection.Compile().Invoke(entity) : null;
    }
}