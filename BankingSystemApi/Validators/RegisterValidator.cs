using BankingSystemApi.DTOs.Auth;
using FluentValidation;

namespace BankingSystemApi.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(3, 50).WithMessage("Name must be between 3 and 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Length(8, 15).WithMessage("Password must be between 8 and 15 characters.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).+$")
                .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one number and one special character.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm Password is required.")
                .Equal(x => x.Password).WithMessage("Passwords do not match.");
        }
    }
}
//DataAnnotations vs FluentValidation
//DataAnnotations	FluentValidation	Use
//[Required]	.NotEmpty()	Value empty nahi honi chahiye
//[StringLength(50)]	.MaximumLength(50)	Maximum length
//[MinLength(3)]	.MinimumLength(3)	Minimum length
//[StringLength(50, MinimumLength = 3)]	.Length(3,50)	Min + Max length
//[EmailAddress]	.EmailAddress()	Email validate
//[Phone]	.Matches(@"^[0-9]{10}$")	Phone validation (industry me Regex zyada use hota hai)
//[Range(1000,100000)]	.InclusiveBetween(1000,100000)	Range
//[Compare("Password")]	.Equal(x => x.Password)	Password match
//[RegularExpression(...)]	.Matches(...)	Regex
//[CreditCard]	.CreditCard()	Credit card
//[Url]	.Must(Uri.IsWellFormedUriString...) ya .Matches(...)	URL
//[Required] (collection)	.NotNull().NotEmpty()	List empty nahiDataAnnotations vs FluentValidation
//DataAnnotations	FluentValidation	Use
//[Required]	.NotEmpty()	Value empty nahi honi chahiye
//[StringLength(50)]	.MaximumLength(50)	Maximum length
//[MinLength(3)]	.MinimumLength(3)	Minimum length
//[StringLength(50, MinimumLength = 3)]	.Length(3,50)	Min + Max length
//[EmailAddress]	.EmailAddress()	Email validate
//[Phone]	.Matches(@"^[0-9]{10}$")	Phone validation (industry me Regex zyada use hota hai)
//[Range(1000,100000)]	.InclusiveBetween(1000,100000)	Range
//[Compare("Password")]	.Equal(x => x.Password)	Password match
//[RegularExpression(...)]	.Matches(...)	Regex
//[CreditCard]	.CreditCard()	Credit card
//[Url]	.Must(Uri.IsWellFormedUriString...) ya .Matches(...)	URL
//[Required] (collection)	.NotNull().NotEmpty()	List empty nahi
