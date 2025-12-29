using System.Linq.Expressions;
using LifeBalance.Application.SharedKernel.Models;
using MediatR;

namespace LifeBalance.Application.UserTracking.Commands;

public class AddUserTrackingCommand : IRequest<BaseResponse>
{
    public AddUserTracking[] Items { get; set; }
    
    public class AddUserTracking
    {
        public int Steps { get; set; }
        public int Calories { get; set; }
        public int WorkoutStreak { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    private static Expression<Func<AddUserTracking, Domain.Entities.UserTracking>> Projection
    {
        get
        {
            return command => new Domain.Entities.UserTracking
            {
                Id = Guid.NewGuid(),
                Steps = command.Steps,
                Calories = command.Calories,
                WorkoutStreak = command.WorkoutStreak,
                CreatedAt = command.CreatedAt
            };
        }
    }

    public static Domain.Entities.UserTracking Create(AddUserTracking command)
    {
        return command != null ? Projection.Compile().Invoke(command) : null;
    }
}