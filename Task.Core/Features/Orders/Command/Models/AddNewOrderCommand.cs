using MediatR;
using Task.Core.ResponseWrapper;

namespace Task.Core.Features.Orders.Command.Models
{
    public class AddNewOrderCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
