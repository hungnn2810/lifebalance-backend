using LifeBalance.Application.UserTracking.Models;
using MediatR;

namespace LifeBalance.Application.UserTracking.Queries;

public class GetUserTrackingQuery : IRequest<UserTrackingDto>
{
}