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

    public async Task<UserTrackingDto> AddAsync(AddUserTrackingCommand command)
    {
        await unitOfWork.BeginTransactionAsync();
        try
        {
            var entity = AddUserTrackingCommand.Create(command);
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

    public async Task<UserTrackingDto> UpdateAsync(UpdateUserTrackingCommand command)
    {
        await unitOfWork.BeginTransactionAsync();
        try
        {
            var checkEntity = await unitOfWork.UserTracking.AsQueryable()
                .Where(x => x.Id == command.Id && x.UserId == userContext.Id)
                .FirstOrDefaultAsync();
            if (checkEntity == null)
                throw new Exception("User tracking not found");

            var entity = UpdateUserTrackingCommand.Create(command);
            entity.UserId = userContext.Id;
            
            var response = await unitOfWork.UserTracking.UpdateAsync(checkEntity.Id, entity);
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