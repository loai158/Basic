using AutoMapper;
using MediatR;
using Task.Core.Features.Products.Query.Models;
using Task.Core.Features.Products.Query.Responses;
using Task.Core.ResponseWrapper;
using Task.Services.Abstracts;

namespace Task.Core.Features.Products.Query.Hadler
{
    public class ProductQueryHandler : IRequestHandler<GetAllProductsQueryModel, Response<IEnumerable<GetAllProductsResponse>>>
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public ProductQueryHandler(IProductServices productServices, IMapper mapper)
        {
            this._productServices = productServices;
            this._mapper = mapper;
        }
        public async Task<Response<IEnumerable<GetAllProductsResponse>>> Handle(GetAllProductsQueryModel request, CancellationToken cancellationToken)
        {
            //get all first 
            var products = await _productServices.GeAllAsync();
            //map
            var result = _mapper.Map<IEnumerable<GetAllProductsResponse>>(products);

            if (result != null)
            {
                return Response<IEnumerable<GetAllProductsResponse>>.Success(result, "Success");
            }
            return Response<IEnumerable<GetAllProductsResponse>>.Fail("No Products ");
        }
    }
}
