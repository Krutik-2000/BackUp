using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Models
{
    public partial class Category
    {
        public Category()
        {
            AllData = new HashSet<AllDatum>();
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<AllDatum> AllData { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
