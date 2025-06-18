using MediatR;
using Task.Core.Features.Orders.Query.Responses;
using Task.Core.ResponseWrapper;

namespace Task.Core.Features.Orders.Query.Models
{
    public class GetAllOrdersQuery : IRequest<Response<IEnumerable<GetAllOrdersResponse>>>
    {
        public string UserId { get; set; }

    }
}
