using System;
using System.Collections.Generic;

#nullable disable

namespace Lab6.DBContext
{
    public partial class ProductOnlineStore
    {
        public ProductOnlineStore()
        {
            Deliveries = new HashSet<Delivery>();
        }

        public int ProductId { get; set; }
        public int StoreId { get; set; }

        public virtual Product Product { get; set; }
        public virtual OnlineStore Store { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
