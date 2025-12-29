using LifeBalance.Application.Repositories.Abstractions;
using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Abstractions;
using LifeBalance.Application.UserTracking.Commands;
using LifeBalance.Application.UserTracking.Models;
using LifeBalance.Application.UserTracking.Queries;
using Microsoft.EntityFrameworkCore;

namespace LifeBalance.Application.Services;

public class UserTrackingService(IUnitOfWork unitOfWork, IUserContext userContext) : IUserTrackingService
{
    public async Task<UserTrackingDto> FindAsync(GetUserTrackingQuery query)
    {
        var entity = await unitOfWork.UserTracking.AsQueryable()
            .Where(x => query.StartDate <= x.CreatedAt && x.CreatedAt <= query.EndDate && x.UserId == userContext.Id)
            .FirstOrDefaultAsync();

        return UserTrackingDto.Create(entity);
    }

    public async Task<UserTrackingDto> AddOrUpdateAsync(AddOrUpdateUserTrackingCommand command)
    {
        await unitOfWork.BeginTransactionAsync();
        try
        {
            // Check if record for the date range already exists
            var checkEntity = await unitOfWork.UserTracking.AsQueryable()
                .Where(x => command.StartDate <= x.CreatedAt && x.CreatedAt <= command.EndDate && x.UserId == userContext.Id)
                .FirstOrDefaultAsync();

            if (checkEntity != null)
            {
                checkEntity.Calories = command.Calories;
                checkEntity.Steps = command.Steps;
                checkEntity.WorkoutStreak = command.WorkoutStreak;
                checkEntity.UpdatedAt = DateTime.UtcNow;

                await unitOfWork.CommitAsync();
                return UserTrackingDto.Create(checkEntity);
            }
            
            var entity = AddOrUpdateUserTrackingCommand.Create(command);
            entity.UserId = userContext.Id;
            
            var response = await unitOfWork.UserTracking.AddAsync(entity);
            await unitOfWork.CommitAsync();
            
            return UserTrackingDto.Create(response);
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }
}