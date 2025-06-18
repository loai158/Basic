using AutoMapper;
using Task.Core.Features.Categories.Command.Models;
using Task.Data.Models.App;

namespace Task.Core.Mapping.Categories
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<AddNewCategoryCommand, Category>();
        }
    }
}
