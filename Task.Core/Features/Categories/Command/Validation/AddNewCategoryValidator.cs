using FluentValidation;
using Task.Core.Features.Categories.Command.Models;
using Task.Infrastructure.Repositry;

namespace Task.Core.Features.Categories.Command.Validation
{
    public class AddNewCategoryValidator : AbstractValidator<AddNewCategoryCommand>
    {
        private readonly ICategoryRepositry _categoryRepositry;

        public AddNewCategoryValidator(ICategoryRepositry categoryRepositry)
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required.")
            .MustAsync(async (name, cancellation) =>
            {
                return await _categoryRepositry.IsCategoryNameUniqueAsync(name);
            }).WithMessage("Category name already exists.");
            this._categoryRepositry = categoryRepositry;
        }
    }
}
