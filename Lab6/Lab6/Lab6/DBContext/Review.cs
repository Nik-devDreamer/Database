using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.DBContext
{
    public partial class Review
    {
        private int rating;

        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string CustomerName { get; set; }
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

        public virtual Product Product { get; set; }
    }
}
