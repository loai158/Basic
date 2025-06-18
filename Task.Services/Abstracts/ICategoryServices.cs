using Task.Data.Models.App;

namespace Task.Services.Abstracts
{
    public interface ICategoryServices
    {
        Task<string> AddNewCategory(Category category);

    }
}
