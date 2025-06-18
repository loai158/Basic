﻿namespace Task.Data.Models.App
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<Product> Products { get; set; }
    }
}
