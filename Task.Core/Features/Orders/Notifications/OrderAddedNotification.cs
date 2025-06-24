using MediatR;

namespace Task.Core.Features.Orders.Notifications
{
    public class OrderAddedNotification : INotification
    {
        public string UserId { get; set; }
        public int OrderId { get; set; }
        public string? Email { get; set; }
    }
}
