using LifeBalance.Application.Exceptions;
using LifeBalance.Application.Exceptions.Helpers;
using LifeBalance.Application.Repositories.Abstractions;
using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Application.Workouts.Commands;
using LifeBalance.Application.Workouts.Models;
using LifeBalance.Application.Workouts.Queries;
using LifeBalance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LifeBalance.Application.Services;

public class WorkoutService(IUnitOfWork unitOfWork, IServiceScopeFactory serviceScopeFactory) : IWorkoutService
{
    public async Task<BaseResponse> AddAsync(AddWorkoutCommand command)
    {
        await unitOfWork.BeginTransactionAsync();
        try
        {
            var existName = await unitOfWork.Workouts.AsQueryable()
                .Where(x => x.Name == command.Name).AnyAsync();
            if (existName)
            {
                throw EntityValidationExceptionHelper.GenerateException(nameof(command.Name),
                    ExceptionErrorCode.DetailCode.ERROR_VALIDATION_DUPLICATED);
            }

            var entity = AddWorkoutCommand.Create(command);
            await unitOfWork.Workouts.AddAsync(entity);
            await unitOfWork.CommitAsync();

            return BaseResponse.Success;
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }

    public async Task<BaseSearchResponse<WorkoutDto>> SearchAsync(SearchWorkoutQuery criteria)
    {
        var start = DateTime.UtcNow;
        var data = new List<WorkoutDto>();
        var response = new BaseSearchResponse<WorkoutDto>(
            duration: 0,
            totalCount: 0,
            pageSize: criteria.PageSize,
            pageIndex: criteria.PageIndex,
            data: data);

        var tasks = new[]
        {
            RetrieveDataAsync(criteria, response),
            CountAsync(criteria, response)
        };

        await Task.WhenAll(tasks);
        var totalMilliseconds = DateTime.UtcNow.Subtract(start).TotalMilliseconds;
        response.DurationInMillisecond = (long)totalMilliseconds;
        return response;
    }

    private async Task RetrieveDataAsync(SearchWorkoutQuery criteria, BaseSearchResponse<WorkoutDto> result)
    {
        using var scope = serviceScopeFactory.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IWorkoutRepository>();
        var query = BuildCriteria(criteria, repository);

        var listResult = await query
            .OrderBy(x => x.Index)
            .Skip(criteria.PageIndex * criteria.PageSize)
            .Take(criteria.PageSize)
            .AsNoTracking()
            .ToListAsync();

        if (listResult.Count != 0)
        {
            result.AddRangeData(listResult.Select(WorkoutDto.Create));
        }
    }

    private async Task CountAsync(SearchWorkoutQuery criteria, BaseSearchResponse<WorkoutDto> result)
    {
        using var scope = serviceScopeFactory.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IWorkoutRepository>();
        var query = BuildCriteria(criteria, repository);

        var count = await query.CountAsync();
        result.TotalCount = count;
    }

    private static IQueryable<Workout> BuildCriteria(SearchWorkoutQuery criteria, IWorkoutRepository repository)
    {
        var query = repository.AsQueryable();

        if (!string.IsNullOrWhiteSpace(criteria.Keyword))
        {
            query = query.Where(x => x.Name.Contains(criteria.Keyword));
        }

        if (criteria.Type.HasValue)
        {
            query = query.Where(x => x.Type == criteria.Type.Value);
        }

        return query;
    }
}