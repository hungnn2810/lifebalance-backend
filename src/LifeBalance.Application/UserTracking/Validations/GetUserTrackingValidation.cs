using FluentValidation;
using LifeBalance.Application.Exceptions;
using LifeBalance.Application.UserTracking.Queries;

namespace LifeBalance.Application.UserTracking.Validations;

public class GetUserTrackingValidation: AbstractValidator<GetUserTrackingQuery>
{
    public GetUserTrackingValidation()
    {
        RuleFor(x => x.StartDate).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);
        RuleFor(x => x.EndDate).NotEmpty().WithMessage(ExceptionErrorCode.DetailCode.ERROR_VALIDATION_REQUIRED);
    }
}