using LifeBalance.Application.Repositories.Abstractions;
using LifeBalance.Domain.Entities;
using LifeBalance.Persistence.DbContexts;

namespace LifeBalance.Persistence.Repositories;

public class UserInformationRepository(AppDbContext context) : GenericRepository<UserInformation, Guid>(context), IUserInformationRepository
{
    protected override void Update(UserInformation requestObject, UserInformation targetObject)
    {
        targetObject.Avatar = requestObject.Avatar;
        targetObject.Age = requestObject.Age;
        targetObject.Height = requestObject.Height;
        targetObject.Weight = requestObject.Weight;
        targetObject.FitnessGoals = requestObject.FitnessGoals;
        targetObject.UpdatedAt = DateTime.UtcNow;
    }
}