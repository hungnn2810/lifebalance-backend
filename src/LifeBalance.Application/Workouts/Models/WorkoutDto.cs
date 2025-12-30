using LifeBalance.Domain.Entities;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Application.Workouts.Models;

public class WorkoutDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public WorkoutType Type { get; set; }
    public string Notes { get; set; }
    public WorkoutBenefit[] Benefits { get; set; }
    public int EstimatedCalories { get; set; }
    public WorkoutStep[] Steps { get; set; }
}