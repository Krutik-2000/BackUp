using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int ProductSku { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public decimal Weight { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
