using Microsoft.EntityFrameworkCore;
using Task.Data.Models.App;
using Task.Infrastructure.UnitOfWorks;
using Task.Services.Abstracts;

namespace Task.Services.Implementations
{
    public class OrderServices : IOrderServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderServices(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<string> AddOrder(Order order)
        {
            foreach (var oi in order.OrderItems)
            {
                var product = await _unitOfWork.Repositry<Product>().GetOne(i => i.Id == oi.ProductId);
                if (product == null)
                    throw new Exception($"Product with ID {oi.ProductId} not found.");

                oi.UnitPrice = product.Price;
            }


            var result = await _unitOfWork.Repositry<Order>().Create(order);

            await _unitOfWork.CompleteAsync();
            return result;
        }

        public async Task<IEnumerable<Order>> GetAllAsync(string userId)
        {
            var orders = await _unitOfWork.Repositry<Order>()
                        .Get(include: c => c.Include(u => u.ApplicationUser).Include(o => o.OrderItems)
                        .ThenInclude(p => p.Product), filter: e => e.ApplicationUserId == userId).ToListAsync();
            return orders;
        }
    }
}
