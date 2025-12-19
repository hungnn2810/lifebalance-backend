namespace LifeBalance.Application.Exceptions;

public class EntityInvalidException(
    string message = null,
    string detailCode = null,
    Exception innerException = null
) : BaseException(ExceptionErrorCode.ERROR_ENTITY_INVALID, message, detailCode, innerException);