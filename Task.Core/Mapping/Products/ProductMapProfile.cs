using AutoMapper;
using Task.Core.Features.Products.Command.Models;

namespace Task.Core.Mapping.Products
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<AddNewProductCommand, Task.Data.Models.App.Product>();
        }
    }
}
