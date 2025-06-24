using MediatR;
using Microsoft.AspNetCore.SignalR;

using Task.Core.Hubs;

namespace Task.Core.Features.Orders.Notifications
{
    public class OrderNotificationHandler : INotificationHandler<OrderAddedNotification>
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public OrderNotificationHandler(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async System.Threading.Tasks.Task Handle(OrderAddedNotification notification, CancellationToken cancellationToken)
        {
            await _hubContext.Clients.User(notification.UserId)
                .SendAsync("ReceiveNotification", $" You Have Ordered new one number: {notification.OrderId}");
        }
    }
}
