using FluentValidation;
using LifeBalance.Application.Exceptions;
using LifeBalance.Application.UserTracking.Commands;

namespace LifeBalance.Application.UserTracking.Validations;

public class AddUserTrackingValidation : AbstractValidator<AddOrUpdateUserTrackingCommand>
{
    public AddUserTrackingValidation()
    {
        RuleFor(x => x.Steps).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED)
            .GreaterThanOrEqualTo(0).WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_INVALID);
        RuleFor(x => x.Calories).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED)
            .GreaterThanOrEqualTo(0).WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_INVALID);
        RuleFor(x => x.WorkoutStreak).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED)
            .GreaterThanOrEqualTo(0).WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_INVALID);
    }
}