using FluentValidation;
using Task.Core.Features.Authentication.Command.Models;

namespace Task.Core.Features.Authentication.Command.Validations
{
    public class LoginUserValidation : AbstractValidator<LoginUserCommand>
    {
        public LoginUserValidation()
        {
            RuleFor(x => x.Email)
           .NotEmpty().WithMessage("Email is required.")
           .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
