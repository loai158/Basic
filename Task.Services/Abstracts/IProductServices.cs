using Task.Data.Models.App;
namespace Task.Services.Abstracts
{
    public interface IProductServices
    {
        public Task<String> AddProductAsync(Product product);
    }
}
