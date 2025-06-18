
using Task.Data.Models.App;

namespace Task.Services.Abstracts
{
    public interface IOrderServices
    {
        Task<string> AddOrder(Order order);
        Task<IEnumerable<Order>> GetAllAsync(string userId);
    }
}
