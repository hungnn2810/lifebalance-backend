using System.Linq.Expressions;
using LifeBalance.Application.UserTracking.Models;
using MediatR;

namespace LifeBalance.Application.UserTracking.Commands;

public class AddOrUpdateUserTrackingCommand : IRequest<UserTrackingDto>
{
    public int Steps { get; set; }
    public int Calories { get; set; }
    public int WorkoutStreak { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    private static Expression<Func<AddOrUpdateUserTrackingCommand, Domain.Entities.UserTracking>> Projection
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
    
    public static Domain.Entities.UserTracking Create(AddOrUpdateUserTrackingCommand command)
    {
        return command != null ? Projection.Compile().Invoke(command) : null;
    }
}