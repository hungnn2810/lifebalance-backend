using FluentValidation;
using LifeBalance.Application.Exceptions;
using LifeBalance.Application.UserInfo.Commands;

namespace LifeBalance.Application.UserInfo.Validations;

public class UpdateUserInfoValidation : AbstractValidator<UpdateUserInfoCommand>
{
    public UpdateUserInfoValidation()
    {
        RuleFor(x => x.Avatar)
            .NotNull()
            .NotEmpty()
            .WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);

        RuleFor(x => x.Age)
            .NotNull()
            .NotNull()
            .WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);

        RuleFor(x => x.Weight)
            .NotNull()
            .NotNull()
            .WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);

        RuleFor(x => x.Height)
            .NotNull()
            .NotNull()
            .WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);

        RuleFor(x => x.FitnessGoals)
            .NotNull()
            .NotEmpty()
            .WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);
    }
}