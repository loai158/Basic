using AutoMapper;
using MediatR;
using Task.Core.Features.Categories.Command.Models;
using Task.Core.ResponseWrapper;
using Task.Data.Models.App;
using Task.Services.Abstracts;

namespace Task.Core.Features.Categories.Command.Handler
{
    public class CategoryCommandHandler : IRequestHandler<AddNewCategoryCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryServices _categoryServices;

        public CategoryCommandHandler(IMapper mapper, ICategoryServices categoryServices)
        {
            this._mapper = mapper;
            this._categoryServices = categoryServices;
        }
        public async Task<Response<string>> Handle(AddNewCategoryCommand request, CancellationToken cancellationToken)
        {
            //Map First
            var Category = _mapper.Map<Category>(request);
            var result = await _categoryServices.AddNewCategory(Category);
            if (result != "Success")
            {
                return Response<string>.Fail("Faild to Add Category");
            }
            return Response<string>.Success("Created");
        }
    }
}
