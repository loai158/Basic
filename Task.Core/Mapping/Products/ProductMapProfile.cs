using AutoMapper;
using Task.Core.Features.Products.Command.Models;
using Task.Core.Features.Products.Query.Responses;
using Task.Data.Models.App;

namespace Task.Core.Mapping.Products
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<AddNewProductCommand, Task.Data.Models.App.Product>();
            CreateMap<Product, GetAllProductsResponse>()
                   .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
