using FluentValidation;
using LifeBalance.Application.Auth.Commands;
using LifeBalance.Application.Exceptions;
using LifeBalance.Application.SharedKernel.Models;

namespace LifeBalance.Application.Auth.Validations;

public class RegisterUserValidation : AbstractValidator<RegisterUser>
{
    public RegisterUserValidation()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED)
            .Must(IsValidEmailFormat).WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_INVALID);
        RuleFor(x => x.Password).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED)
            .MaximumLength(128).WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_MAX_LENGTH);
    }

    private static bool IsValidEmailFormat(string email)
    {
        return StringRegex.EMAIL_REGEX.IsMatch(email);
    }
}