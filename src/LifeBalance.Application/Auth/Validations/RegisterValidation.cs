using FluentValidation;
using LifeBalance.Application.Auth.Commands;
using LifeBalance.Application.Exceptions;
using LifeBalance.Application.SharedKernel.Models;

namespace LifeBalance.Application.Auth.Validations;

public class RegisterValidation : AbstractValidator<RegisterCommand>
{
    public RegisterValidation()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED)
            .Must(ValidatorHelper.IsValidEmailFormat).WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_INVALID);
        
        RuleFor(x => x.Password).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED)
            .MaximumLength(128).WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_MAX_LENGTH);
       
        RuleFor(x => x.Name).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);
    }
}