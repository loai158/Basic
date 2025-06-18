using FluentValidation;
using Task.Core.Features.Products.Command.Models;

namespace Task.Core.Features.Products.Command.Validation
{
    public class AddNewProductCommandValidator : AbstractValidator<AddNewProductCommand>
    {
        public AddNewProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price must be non-negative.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity must be non-negative.");

            RuleFor(p => p.CategoryId)
                  .GreaterThan(0).WithMessage("Please select a valid category.");
        }
    }
}
