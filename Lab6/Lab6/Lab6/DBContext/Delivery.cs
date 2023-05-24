using System;
using System.Collections.Generic;

#nullable disable

namespace Lab6.DBContext
{
    public partial class Delivery
    {
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime? DateDelivery { get; set; }
        public string AddressDelivery { get; set; }
        public decimal Amount { get; set; }

        public virtual ProductOnlineStore ProductOnlineStore { get; set; }
    }
}
