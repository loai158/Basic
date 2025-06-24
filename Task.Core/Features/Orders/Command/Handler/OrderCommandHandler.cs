using AutoMapper;
using MediatR;
using Task.Core.Features.Orders.Command.Models;
using Task.Core.Features.Orders.Notifications;
using Task.Core.Mapping.Orders;
using Task.Core.ResponseWrapper;
using Task.Services.Abstracts;
namespace Task.Core.Features.Orders.Command.Handler
{
    public class OrderCommandHandler : IRequestHandler<AddNewOrderCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderServices _orderServices;
        private readonly IMediator _mediator;
        private readonly IUserServices _userServices;

        public OrderCommandHandler(IMapper mapper, IOrderServices orderServices, IMediator mediator, IUserServices userServices)
        {
            this._mapper = mapper;
            this._orderServices = orderServices;
            this._mediator = mediator;
            this._userServices = userServices;
        }
        public async Task<Response<string>> Handle(AddNewOrderCommand request, CancellationToken cancellationToken)
        {
            //fast check for the email and empty items
            if (string.IsNullOrWhiteSpace(request.UserId) || !request.OrderItems.Any())
                return Response<string>.Fail("Invalid order data.");

            //map AddNewOrderCommand to (OrderItems and Orders )
            var Order = request.MapFroAddToOrder();

            //Create Order 

            var result = await _orderServices.AddOrder(Order);
            if (result != "Success")
            {
                return Response<string>.Fail("Faild to Add Order");
            }
            await _mediator.Publish(new OrderAddedNotification
            {
                UserId = request.UserId,
                OrderId = Order.Id,
                Email = await _userServices.GetEmailByIdAsync(Order.ApplicationUserId),
            });

            return Response<string>.Success("Created");
            throw new NotImplementedException();
        }
    }
}
