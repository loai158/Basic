namespace Task.Data.Models.App
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        // Navigation properties
        public Category Category { get; set; }
    }
}
