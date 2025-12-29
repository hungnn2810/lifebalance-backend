using FluentValidation;
using LifeBalance.Application.Exceptions;
using LifeBalance.Application.UserTracking.Commands;

namespace LifeBalance.Application.UserTracking.Validations;

public class AddOrUpdateUserTrackingValidation : AbstractValidator<AddOrUpdateUserTrackingCommand>
{
    public AddOrUpdateUserTrackingValidation()
    {
        RuleFor(x => x.Items)
            .NotNull()
            .NotEmpty()
            .WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);

        RuleForEach(x => x.Items)
            .SetValidator(new AddOrUpdateUserTrackingItemValidator());
    }
}

public class AddOrUpdateUserTrackingItemValidator : AbstractValidator<AddOrUpdateUserTrackingCommand.AddOrUpdateUserTracking>
{
    public AddOrUpdateUserTrackingItemValidator()
    {
        RuleFor(x => x.Steps)
            .GreaterThanOrEqualTo(0)
            .WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_INVALID);

        RuleFor(x => x.Calories)
            .GreaterThanOrEqualTo(0)
            .WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_INVALID);

        RuleFor(x => x.WorkoutStreak)
            .GreaterThanOrEqualTo(0)
            .WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_INVALID);

        RuleFor(x => x.StartDate)
            .LessThanOrEqualTo(x => x.EndDate)
            .WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_INVALID);
    }
}