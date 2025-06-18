using AutoMapper;
using MediatR;
using Task.Core.Features.Orders.Command.Models;
using Task.Core.Mapping.Orders;
using Task.Core.ResponseWrapper;
using Task.Services.Abstracts;

namespace Task.Core.Features.Orders.Command.Handler
{
    public class OrderCommandHandler : IRequestHandler<AddNewOrderCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderServices _orderServices;

        public OrderCommandHandler(IMapper mapper, IOrderServices orderServices)
        {
            this._mapper = mapper;
            this._orderServices = orderServices;
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
            return Response<string>.Success("Created");
            throw new NotImplementedException();
        }
    }
}
