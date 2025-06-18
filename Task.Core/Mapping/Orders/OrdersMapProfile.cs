using Task.Core.Features.Orders.Command.Models;
using Task.Core.Features.Orders.Query.Responses;
using Task.Data.Models.App;

namespace Task.Core.Mapping.Orders
{
    public static class OrdersMapProfile
    {
        public static Order MapFroAddToOrder(this AddNewOrderCommand command)
        {

            return new Order()
            {

                ApplicationUserId = command.UserId,
                OrderDate = DateTime.UtcNow,
                OrderItems = command.OrderItems?.Select(oi => new OrderItem
                {
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,

                }).ToList() ?? new List<OrderItem>()
            };

        }
        public static GetAllOrdersResponse FromOrderToResponse(this Order order)
        {
            return new GetAllOrdersResponse
            {
                CreatedAt = order.OrderDate,
                TotalPrice = order.TotalPrice,
                CustomerName = order.ApplicationUser.FullName,
                OrderId = order.Id,
                OrderItems = order.OrderItems?.Select(oi => new Task.Core.Features.Orders.Query.Responses.OrderItemDto
                {
                    ProductName = oi.Product.Name,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                }).ToList() ?? new List<Features.Orders.Query.Responses.OrderItemDto>()
            };
        }
        public static IEnumerable<GetAllOrdersResponse> MapFromOrdersToResponse(this IEnumerable<Order> orders)
        {
            return orders.Select(c => c.FromOrderToResponse());
        }
    }

}

