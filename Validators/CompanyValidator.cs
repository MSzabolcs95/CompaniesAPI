using FluentValidation;

public class CompanyValidator : AbstractValidator<Company>
{
    public CompanyValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Company name is required.")
            .MaximumLength(100).WithMessage("Company name cannot exceed 100 characters.");

        RuleFor(c => c.Isin)
            .NotEmpty().WithMessage("ISIN is required.")
            .Matches("^[A-Za-z]{2}[0-9]{10}$").WithMessage("ISIN must start with two letters followed by 10 numbers.");

        RuleFor(c => c.Ticker)
            .NotEmpty().WithMessage("Stock ticker is required.")
            .MaximumLength(10).WithMessage("Stock ticker cannot exceed 10 characters.");
    }
}
