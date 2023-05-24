using System;
using System.Collections.Generic;

#nullable disable

namespace Lab6.DBContext
{
    public partial class Order
    {
        public DateTime DateOrder { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual OnlineStore Store { get; set; }
    }
}
