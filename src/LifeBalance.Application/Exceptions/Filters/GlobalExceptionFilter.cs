using System.Diagnostics;
using LifeBalance.Application.Exceptions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace LifeBalance.Application.Exceptions.Filters;

public class GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger) : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        context.ExceptionHandled = true;
        logger.LogError(exception, "Message: {Message}", exception.Message);

        string traceId = string.Empty;
        if (Activity.Current != null)
        {
            traceId = Activity.Current.Context.TraceId.ToString();
        }
        
        switch (exception)
        {
            case EntityValidationException validation:
                context.Result = new BadRequestObjectResult(new ValidationResultApiResponse(
                    false,
                    validation.ErrorCode,
                    validation.DetailCode,
                    validation.Failures,
                    traceId)
                );
                context.ExceptionHandled = true;
                break;

            case EntityNotFoundException notFoundValidation:
                context.Result = new NotFoundObjectResult(new
                {
                    Success = false,
                    Message = notFoundValidation.Message,
                    ErrorCode = notFoundValidation.ErrorCode,
                    DetailCode = notFoundValidation.DetailCode,
                    TraceId = traceId
                });
                context.ExceptionHandled = true;
                break;

            case BaseException baseException:
                context.Result = new BadRequestObjectResult(new
                {
                    IsSuccess = false,
                    Message = baseException.Message,
                    ErrorCode = baseException.ErrorCode,
                    DetailCode = baseException.DetailCode,
                    TraceId = traceId
                });
                context.ExceptionHandled = true;
                break;

            default:
                context.Result = new BadRequestObjectResult(new
                {
                    IsSuccess = false,
                    ErrorCode = ExceptionErrorCode.ERROR_GENERIC_COMMON_EXCEPTION,
                    TraceId = traceId
                });
                break;
        }
    }
}