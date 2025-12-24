using FluentValidation;
using LifeBalance.Application.Auth.Commands;
using LifeBalance.Application.Exceptions;
using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Application.Auth.Validations;

public class ExternalLoginValidation : AbstractValidator<ExternalLoginCommand>
{
    public ExternalLoginValidation()
    {
        RuleFor(x => x.IdToken).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);

        RuleFor(x => x.Provider).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED)
            .Must(p => Enum.IsDefined(typeof(AuthProvider), p)).WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_INVALID);

        RuleFor(x => x.ProviderKey).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);

        RuleFor(x => x.Email).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED)
            .Must(ValidatorHelper.IsValidEmailFormat).WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_INVALID);

        RuleFor(x => x.Name).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);
    }
}