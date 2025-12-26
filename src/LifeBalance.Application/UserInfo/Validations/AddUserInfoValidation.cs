using FluentValidation;
using LifeBalance.Application.Exceptions;
using LifeBalance.Application.UserInfo.Commands;

namespace LifeBalance.Application.UserInfo.Validations;

public class AddUserInfoValidation : AbstractValidator<AddUserInfoCommand>
{
    public AddUserInfoValidation()
    {
        RuleFor(x => x.Avatar).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);
        RuleFor(x => x.Age).NotNull().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);
        RuleFor(x => x.Weight).NotNull().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);
        RuleFor(x => x.Height).NotNull().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);
        RuleFor(x => x.FitnessGoals).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);
    }
}