namespace LifeBalance.Application.SharedKernel.Models;

public class BaseResponse(bool isSuccess, string message)
{
    public bool IsSuccess { get; set; } = isSuccess;
    public string Message { get; set; } = message;

    public static BaseResponse Success => new BaseResponse(true, string.Empty);
    public static BaseResponse Failure => new BaseResponse(false, string.Empty);
}