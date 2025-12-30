namespace LifeBalance.Application.Workouts.Models;

public class WorkoutStepDto
{
    public string Title { get; set; }
    public short StepOrder { get; set; }
    public string Description { get; set; }
    public WorkoutStepMediaDto[] Medias { get; set; }
}