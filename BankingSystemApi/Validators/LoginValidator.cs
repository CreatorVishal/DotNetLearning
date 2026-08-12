using BankingSystemApi.DTOs.Auth;
using FluentValidation;

namespace BankingSystemApi.Validators
{
    public class LoginValidator:AbstractValidator<LoginUserDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
