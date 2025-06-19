using MediatR;
using Task.Core.Features.Products.Query.Responses;
using Task.Core.ResponseWrapper;

namespace Task.Core.Features.Products.Query.Models
{
    public class GetAllProductsQueryModel : IRequest<Response<IEnumerable<GetAllProductsResponse>>>
    {
    }
}
