using LifeBalance.Application.Repositories.Abstractions;
using LifeBalance.Domain.Entities;
using LifeBalance.Persistence.DbContexts;

namespace LifeBalance.Persistence.Repositories;

public class WorkoutRepository(AppDbContext context) : GenericRepository<Workout, Guid>(context), IWorkoutRepository
{
    protected override void Update(Workout requestObject, Workout targetObject)
    {
        throw new NotImplementedException();
    }
}