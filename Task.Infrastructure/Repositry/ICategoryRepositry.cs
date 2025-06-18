using Task.Data.Models.App;
using Task.Infrastructure.InfrastructureBases;

namespace Task.Infrastructure.Repositry
{
    public interface ICategoryRepositry : IGenericRepositryAsync<Category>
    {
        Task<bool> IsCategoryNameUniqueAsync(string name);

    }
}
