using LifeBalance.Application.Repositories.Abstractions;
using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Abstractions;
using LifeBalance.Application.SharedKernel.Models;
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

    public async Task<BaseResponse> AddAsync(AddUserTrackingCommand command)
    {
        await unitOfWork.BeginTransactionAsync();
        try
        {
            foreach (var item in command.Items)
            {
                var entity = AddUserTrackingCommand.Create(item);
                entity.UserId = userContext.Id;

                await unitOfWork.UserTracking.AddAsync(entity);
            }

            await unitOfWork.CommitAsync();

            return BaseResponse.Success;
        }
        catch (Exception)
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }
}