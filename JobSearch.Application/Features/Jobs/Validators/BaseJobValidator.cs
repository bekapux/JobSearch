using FluentValidation;

namespace JobSearch.Application.Features.Jobs.Validators;

public class BaseJobValidator : AbstractValidator<BaseJob>
{

    public BaseJobValidator()
    {
        RuleFor(x => x.VacancyName)
            .MinimumLength(3)
                .WithMessage("{PropertyName} must be at least 3 characters")
            .NotEmpty()
                .WithMessage("{PropertyName} must not be empty");

        RuleFor(x => x.CompanyName)
            .MinimumLength(2)
                .WithMessage("{PropertyName} must be at least 3 characters")
            .NotEmpty()
                .WithMessage("{PropertyName} must not be empty");
    }
}
