using System;
using System.Collections.Generic;

#nullable disable

namespace Lab6.DBContext
{
    public partial class Product
    {
        private int rating;

        public Product()
        {
            Orders = new HashSet<Order>();
            ProductOnlineStores = new HashSet<ProductOnlineStore>();
            Reviews = new HashSet<Review>();
        }

        public int ProductId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string NameProduct { get; set; }
        public string Manufacturer { get; set; }
        public int Rating
        {
            get { return rating; }
            set
            {
                if (value < 1)
                    rating = 1;
                else if (value > 5)
                    rating = 5;
                else
                    rating = value;
            }
        }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductOnlineStore> ProductOnlineStores { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
