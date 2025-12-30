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
            .NotEmpty()
            .WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);

        RuleFor(x => x.Weight)
            .NotNull()
            .NotEmpty()
            .WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);

        RuleFor(x => x.Height)
            .NotNull()
            .NotEmpty()
            .WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);
        
        RuleFor(x => x.Gender)
            .NotNull()
            .NotEmpty()
            .WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);

        RuleFor(x => x.FitnessGoals)
            .NotNull()
            .NotEmpty()
            .WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);
    }
}