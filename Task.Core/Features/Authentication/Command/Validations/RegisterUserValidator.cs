using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Task.Core.Features.Authentication.Command.Models;
using Task.Data.Models.Identity;

namespace Task.Core.Features.Authentication.Command.Validation
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator(UserManager<ApplicationUser> userManager)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(50);

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required")
                .MinimumLength(4).MaximumLength(20)
                .MustAsync(async (username, cancellation) =>
                {
                    var existingUser = await userManager.FindByNameAsync(username);
                    return existingUser == null;
                })
                .WithMessage("Username is already taken");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format")
                .MustAsync(async (email, cancellation) =>
                {
                    var existingUser = await userManager.FindByEmailAsync(email);
                    return existingUser == null;
                })
                .WithMessage("Email is already registered");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long");
        }
    }
}
