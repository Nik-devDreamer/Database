using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.DBContext.Repository
{
    public class ProductsRepository : IProducts
    {
        private Internet_SalesContext context;

        public ProductsRepository(Internet_SalesContext context)
        {
            this.context = context;
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public void ChangeProductInformation(Product product, string newDescription, decimal newPrice, string newManufacturer, int newRating)
        {
            product.Description = newDescription;
            product.Price = newPrice;
            product.Manufacturer = newManufacturer;
            product.Rating = newRating;
            context.SaveChanges();
        }
    }
}
