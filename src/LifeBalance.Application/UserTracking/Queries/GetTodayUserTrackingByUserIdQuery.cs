using LifeBalance.Application.UserTracking.Models;
using MediatR;

namespace LifeBalance.Application.UserTracking.Queries;

public class GetTodayUserTrackingByUserIdQuery(Guid userId) : IRequest<UserTrackingDto>
{
    public Guid UserId { get; set; } = userId;
}