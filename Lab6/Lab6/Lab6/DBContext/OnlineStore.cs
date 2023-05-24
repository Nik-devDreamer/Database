using System;
using System.Collections.Generic;

#nullable disable

namespace Lab6.DBContext
{
    public partial class OnlineStore
    {
        public OnlineStore()
        {
            Orders = new HashSet<Order>();
            ProductOnlineStores = new HashSet<ProductOnlineStore>();
        }

        public int StoreId { get; set; }
        public string AddressStore { get; set; }
        public string Telephone { get; set; }
        public string NameStore { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductOnlineStore> ProductOnlineStores { get; set; }
    }
}
