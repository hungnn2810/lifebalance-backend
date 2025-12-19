using FluentValidation.Results;

namespace LifeBalance.Application.Exceptions;

public class EntityValidationException(
    string message = null,
    string detailCode = null,
    Exception innerException = null
) : BaseException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION, message, detailCode, innerException)
{
    public IDictionary<string, string[]> Failures { get; } = new Dictionary<string, string[]>();

    public EntityValidationException(
        List<ValidationFailure> failures,
        string message = null,
        string detailCode = null,
        Exception innerException = null) : this(message, detailCode, innerException)
    {
        var propertyNames = failures.Select(f => f.PropertyName).Distinct();
        foreach (var propertyName in propertyNames)
        {
            var propertyFailures = failures.Where(f => f.PropertyName == propertyName).Select(f => f.ErrorMessage).ToArray();
            Failures.Add(propertyName, propertyFailures);
        }

        if (failures.Any(f => f.ErrorMessage.Contains("NOT_FOUND") || f.ErrorMessage.Contains("SOME_ITEMS_DELETED")))
        {
            SetDetailCode(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_SOME_ITEMS_DELETED);
        }
    }
}