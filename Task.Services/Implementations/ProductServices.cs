using Microsoft.EntityFrameworkCore;
using Task.Data.Models.App;
using Task.Infrastructure.UnitOfWorks;
using Task.Services.Abstracts;

namespace Task.Services.Implementations
{
    public class ProductServices : IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductServices(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<string> AddProductAsync(Product product)
        {
            var result = await _unitOfWork.Repositry<Product>().Create(product);
            await _unitOfWork.CompleteAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GeAllAsync()
        {
            var products = await _unitOfWork.Repositry<Product>().Get(include: c => c.Include(ca => ca.Category)).ToListAsync();
            return products;
        }
    }
}
