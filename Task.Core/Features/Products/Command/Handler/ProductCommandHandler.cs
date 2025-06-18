using AutoMapper;
using MediatR;
using Task.Core.Features.Products.Command.Models;
using Task.Core.ResponseWrapper;
using Task.Data.Models.App;
using Task.Services.Abstracts;
namespace Task.Core.Features.Products.Command.Handler
{
    public class ProductCommandHandler : IRequestHandler<AddNewProductCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IProductServices _productServices;

        public ProductCommandHandler(IMapper mapper, IProductServices productServices)
        {
            this._mapper = mapper;
            this._productServices = productServices;
        }
        public async Task<Response<string>> Handle(AddNewProductCommand request, CancellationToken cancellationToken)
        {
            // After Validation Map From command To Real Product 
            var Product = _mapper.Map<Product>(request);
            //add to DB
            var result = await _productServices.AddProductAsync(Product);
            if (result != "Success")
            {
                return Response<string>.Fail("Faild to Add Product");
            }
            return Response<string>.Success("Created");
        }
    }
}
