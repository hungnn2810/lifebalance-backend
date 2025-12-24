namespace LifeBalance.Application.SharedKernel.Models;

public static class ValidatorHelper
{
    public static bool IsValidEmailFormat(string email)
    {
        return StringRegex.EMAIL_REGEX.IsMatch(email);
    }
}