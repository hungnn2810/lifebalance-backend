namespace LifeBalance.Application.SharedKernel.Models;

public class BaseResponse(bool success, string message)
{
    public bool Success { get; set; } = success;
    public string Message { get; set; } = message;

    public static BaseResponse CreateSuccess => new BaseResponse(true, string.Empty);
    public static BaseResponse CreateFailure => new BaseResponse(false, string.Empty);
}