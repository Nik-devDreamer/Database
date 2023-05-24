using Lab6.DBContext;
using Lab6.DBContext.Repository;
using System;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = new Product()
            {
                Description = "Описание",
                Price = 10.8m,
                Category = "Категория",
                NameProduct = "Название продукта",
                Manufacturer = "Производитель",
                Rating = 5
            };
            var review = new Review()
            {
                CustomerName = "Nik",
                Description = "Хороший продукт",
                Rating = 4
            };
            using (var db = new Internet_SalesContext())
            {
                var productRepository = new ProductsRepository(db);

                productRepository.AddProduct(product);
                product.Reviews.Add(review);
                productRepository.DeleteProduct(product);
                product.Reviews.Remove(review);
            }
        }
    }
}
