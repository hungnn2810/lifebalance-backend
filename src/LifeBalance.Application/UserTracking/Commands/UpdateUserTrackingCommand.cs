using System.Linq.Expressions;
using LifeBalance.Application.UserTracking.Models;
using MediatR;

namespace LifeBalance.Application.UserTracking.Commands;

public class UpdateUserTrackingCommand(Guid id) : IRequest<UserTrackingDto>
{
    public Guid Id { get; set; } = id;
    public int Steps { get; set; }
    public int Calories { get; set; }
    public int WorkoutStreak { get; set; }

    private static Expression<Func<UpdateUserTrackingCommand, Domain.Entities.UserTracking>> Projection
    {
        get
        {
            return command => new Domain.Entities.UserTracking
            {
                Id = command.Id,
                Steps = command.Steps,
                Calories = command.Calories,
                WorkoutStreak = command.WorkoutStreak
            };
        }
    }
    
    public static Domain.Entities.UserTracking Create(UpdateUserTrackingCommand command)
    {
        return command != null ? Projection.Compile().Invoke(command) : null;
    }
}