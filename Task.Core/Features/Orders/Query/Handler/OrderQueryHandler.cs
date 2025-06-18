using MediatR;
using Task.Core.Features.Orders.Query.Models;
using Task.Core.Features.Orders.Query.Responses;
using Task.Core.Mapping.Orders;
using Task.Core.ResponseWrapper;
using Task.Services.Abstracts;

namespace Task.Core.Features.Orders.Query.Handler
{
    public class OrderQueryHandler : IRequestHandler<GetAllOrdersQuery, Response<IEnumerable<GetAllOrdersResponse>>>
    {
        private readonly IOrderServices _orderServices;

        public OrderQueryHandler(IOrderServices orderServices)
        {
            this._orderServices = orderServices;
        }
        public async Task<Response<IEnumerable<GetAllOrdersResponse>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            //get first 
            var orders = await _orderServices.GetAllAsync(request.UserId);
            //then map to response
            var result = orders.MapFromOrdersToResponse();
            if (result == null)
            {
                return Response<IEnumerable<GetAllOrdersResponse>>.Fail("You Does Not Have Any Orders Yet ");
            }
            return Response<IEnumerable<GetAllOrdersResponse>>.Success(result, "Created");

        }
    }
}
