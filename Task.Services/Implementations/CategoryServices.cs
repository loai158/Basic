using Task.Data.Models.App;
using Task.Infrastructure.UnitOfWorks;
using Task.Services.Abstracts;

namespace Task.Services.Implementations
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryServices(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<string> AddNewCategory(Category category)
        {
            var result = await _unitOfWork.Repositry<Category>().Create(category);
            await _unitOfWork.CompleteAsync();
            return result;
        }
    }
}
