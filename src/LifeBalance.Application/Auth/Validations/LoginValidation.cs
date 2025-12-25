using FluentValidation;
using LifeBalance.Application.Auth.Commands;
using LifeBalance.Application.Exceptions;
using LifeBalance.Application.SharedKernel.Models;

namespace LifeBalance.Application.Auth.Validations;

public class LoginValidation : AbstractValidator<LoginCommand>
{
    public LoginValidation()
    {
        RuleFor(c => c.Email).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);
        RuleFor(c => c.Password).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);
    }
}