using System.Linq.Expressions;
using LifeBalance.Application.SharedKernel.Models;
using MediatR;

namespace LifeBalance.Application.UserTracking.Commands;

public class AddOrUpdateUserTrackingCommand : IRequest<BaseResponse>
{
    public AddOrUpdateUserTracking[] Items { get; set; }
    
    public class AddOrUpdateUserTracking
    {
        public int Steps { get; set; }
        public int Calories { get; set; }
        public int WorkoutStreak { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    private static Expression<Func<AddOrUpdateUserTracking, Domain.Entities.UserTracking>> Projection
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

    public static Domain.Entities.UserTracking Create(AddOrUpdateUserTracking command)
    {
        return command != null ? Projection.Compile().Invoke(command) : null;
    }
}