using Microsoft.AspNetCore.Mvc;

namespace LifeBalance.Application.Exceptions.Filters;

public static class MiddlewareExtension
{
    public static void ExceptionHandling(this MvcOptions options)
    {
        options.Filters.Add(typeof(GlobalExceptionFilter));
    }
}