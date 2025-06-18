using System.ComponentModel.DataAnnotations.Schema;
using Task.Data.Models.Identity;

namespace Task.Data.Models.App
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public decimal TotalPrice => OrderItems?.Sum(item => item.UnitPrice * item.Quantity) ?? 0;
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
