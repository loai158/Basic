using FluentValidation;
using Task.Core.Features.Orders.Command.Models;

namespace Task.Core.Features.Orders.Command.Validation
{
    public class AddNewOrderValidator : AbstractValidator<AddNewOrderCommand>
    {
        public AddNewOrderValidator()
        {

            RuleFor(x => x.OrderItems)
                .NotNull().WithMessage("Order must contain items.")
                .Must(x => x.Any()).WithMessage("Order must contain at least one item.");

            RuleForEach(x => x.OrderItems).SetValidator(new OrderItemDtoValidator());
        }
        public class OrderItemDtoValidator : AbstractValidator<OrderItemDto>
        {
            public OrderItemDtoValidator()
            {
                RuleFor(x => x.ProductId)
                    .GreaterThan(0).WithMessage("Product ID must be greater than 0.");

                RuleFor(x => x.Quantity)
                    .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            }
        }
    }
}
