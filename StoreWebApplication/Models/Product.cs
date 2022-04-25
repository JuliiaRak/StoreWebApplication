using System;
using System.Collections.Generic;

namespace StoreWebApplication
{
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
            ProductImages = new HashSet<ProductImage>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }
        public byte[]? Image { get; set; }
        public int NumberLeft { get; set; }
        public double ProductWeight { get; set; }
        public int FirmId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Firm Firm { get; set; } = null!;
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
