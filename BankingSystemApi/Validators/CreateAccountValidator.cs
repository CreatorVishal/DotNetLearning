using BankingSystemApi.DTOs;
using FluentValidation;

namespace BankingSystemApi.Validators
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountDto>
    {
        public CreateAccountValidator()
        {
            RuleFor(x => x.AccountHolderName)
                .NotEmpty().WithMessage("Account Holder Name is required.")
                .Length(3, 50).WithMessage("Account Holder Name must be between 3 and 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required.")
                .Matches(@"^[0-9]{10}$")
                .WithMessage("Phone Number must contain exactly 10 digits.");

            RuleFor(x => x.Balance)
                .InclusiveBetween(1000, 10000000)
                .WithMessage("Opening balance must be between ₹1000 and ₹10000000.");
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
