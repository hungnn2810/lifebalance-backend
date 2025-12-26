using System.Linq.Expressions;
using LifeBalance.Application.UserTracking.Models;
using MediatR;

namespace LifeBalance.Application.UserTracking.Commands;

public class AddUserTrackingCommand : IRequest<UserTrackingDto>
{
    public int Steps { get; set; }
    public int Calories { get; set; }
    public int WorkoutStreak { get; set; }

    private static Expression<Func<AddUserTrackingCommand, Domain.Entities.UserTracking>> Projection
    {
        get
        {
            return command => new Domain.Entities.UserTracking
            {
                Id = Guid.NewGuid(),
                Steps = command.Steps,
                Calories = command.Calories,
                WorkoutStreak = command.WorkoutStreak,
            };
        }
    }
    
    public static Domain.Entities.UserTracking Create(AddUserTrackingCommand command)
    {
        return command != null ? Projection.Compile().Invoke(command) : null;
    }
}