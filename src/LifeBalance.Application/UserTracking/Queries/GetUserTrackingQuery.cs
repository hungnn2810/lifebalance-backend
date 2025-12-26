using LifeBalance.Application.UserTracking.Models;
using MediatR;

namespace LifeBalance.Application.UserTracking.Queries;

public class GetUserTrackingQuery(DateTime startDate, DateTime endDate) : IRequest<UserTrackingDto>
{
    public DateTime StartDate { get; set; } = startDate;
    public DateTime EndDate { get; set; } = endDate;
}