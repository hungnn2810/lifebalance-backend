namespace LifeBalance.Application.Exceptions.Models;

public class ValidationResultApiResponse(bool isSuccess, string errorCode, string detailCode, string traceId)
{
    public bool IsSuccess { get; } = isSuccess;
    public string Message { get; set; } = ExceptionErrorCode.DetailCode.ERROR_VALIDATION;

    public string ErrorCode { get; set; } = errorCode;
    public string DetailCode { get; set; } = detailCode;
    public string TraceId { get; set; } = traceId;

    public ICollection<FieldFailureMessage> Fields { get; } = new LinkedList<FieldFailureMessage>();

    public ValidationResultApiResponse(
        bool isSuccess,
        string errorCode,
        string detailCode,
        IDictionary<string, string[]> failures,
        string traceId
    ) : this(isSuccess, errorCode, detailCode, traceId)
    {
        Fields = failures.SelectMany(fieldFailures =>
            fieldFailures.Value.Select(item =>
                new FieldFailureMessage(fieldFailures.Key, item))).ToList();
    }

    public class FieldFailureMessage(string name, string errorCode)
    {
        public string Name { get; set; } = name;
        public string ErrorCode { get; set; } = errorCode;
    }
}