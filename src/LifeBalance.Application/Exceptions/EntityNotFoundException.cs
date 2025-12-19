namespace LifeBalance.Application.Exceptions;

public class EntityNotFoundException(
    string message = null,
    string detailCode = null,
    Exception innerException = null
) : BaseException(ExceptionErrorCode.ERROR_ENTITY_NOT_FOUND, message, detailCode, innerException);