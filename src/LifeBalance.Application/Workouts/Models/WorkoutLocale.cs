namespace LifeBalance.Application.Workouts.Models;

public class WorkoutLocale
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Notes { get; set; }
    public string[] Benefits { get; set; }
    public WorkoutStepLocale[] Steps { get; set; }
}

public class WorkoutStepLocale
{
    public string Title { get; set; }
    public string Description { get; set; }
}