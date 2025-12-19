namespace LifeBalance.Application.Exceptions;

public class BaseException(
    string errorCode,
    string message,
    string detailCode,
    Exception innerException
) : Exception(message, innerException)
{
    public string ErrorCode { get; private set; } = errorCode;
    public string DetailCode { get; private set; } = detailCode;

    internal void SetErrorCode(string errorCode)
    {
        ErrorCode = errorCode;
    }

    internal void SetDetailCode(string detailCode)
    {
        DetailCode = detailCode;
    }
}