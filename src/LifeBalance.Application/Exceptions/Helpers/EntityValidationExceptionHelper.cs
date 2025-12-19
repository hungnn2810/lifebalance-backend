
using FluentValidation.Results;

namespace LifeBalance.Application.Exceptions.Helpers;

public static class EntityValidationExceptionHelper
{
    public static EntityValidationException GenerateException(
        List<ValidationFailure> failures,
        string message = null,
        string detailCode = null,
        Exception innerException = null)
    {
        return new EntityValidationException(failures, message, detailCode, innerException);
    }
    
    public static EntityValidationException GenerateException(
        string fieldName,
        string fieldErrorMessage,
        string message = null,
        string detailCode = null,
        Exception innerException = null)
    {
        var failure = new ValidationFailure(fieldName, fieldErrorMessage);
        return new EntityValidationException([failure], message, detailCode, innerException);
    }
}