using CareerConnectApi.DTOs;
using FluentValidation;

namespace CareerConnectApi.Validators;

public class CreateCompanyValidator : AbstractValidator<CreateCompanyDto>
{
    public CreateCompanyValidator()
    {
        RuleFor(x => x.CompanyName)
            .NotEmpty()
            .WithMessage("Company Name Required")
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email Required")
            .EmailAddress()
            .WithMessage("Invalid Email");
    }
}