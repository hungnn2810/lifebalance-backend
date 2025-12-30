
using LifeBalance.Domain.Enums;

namespace LifeBalance.Application.Workouts.Models;

public class WorkoutStepMediaDto
{
    public MediaType MediaType { get; set; }
    public string ObjectKey { get; set; }
    public string Url { get; set; }
    public int SortOrder { get; set; }
}