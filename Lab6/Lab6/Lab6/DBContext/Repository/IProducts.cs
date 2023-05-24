using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.DBContext.Repository
{
    public interface IProducts
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void ChangeProductInformation(Product product, string newDescription, decimal newPrice, string newManufacturer, int newRating);
    }
}
