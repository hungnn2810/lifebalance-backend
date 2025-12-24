using FluentValidation;
using LifeBalance.Application.Auth.Commands;
using LifeBalance.Application.Exceptions;

namespace LifeBalance.Application.Auth.Validations;

public class RefreshTokenValidation : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenValidation()
    {
        RuleFor(x => x.Token).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);
    }
}