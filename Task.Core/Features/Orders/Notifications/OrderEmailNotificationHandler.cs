using MediatR;
using Task.Services.Abstracts;

namespace Task.Core.Features.Orders.Notifications
{
    public class OrderEmailNotificationHandler : INotificationHandler<OrderAddedNotification>
    {
        private readonly IEmailService _emailService;

        public OrderEmailNotificationHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async System.Threading.Tasks.Task Handle(OrderAddedNotification notification, CancellationToken cancellationToken)
        {
            string subject = $"Order #{notification.OrderId} Created";
            string body = $"<p>Your order <strong>#{notification.OrderId}</strong> has been created successfully.</p>";
            await _emailService.SendEmailAsync(notification.Email, subject, body);
        }
    }

}
