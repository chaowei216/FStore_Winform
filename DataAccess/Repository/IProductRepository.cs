using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product? GetProductById(int id);
        Product? GetProductByName(string name);
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
        ICollection<Product> GetProductByUnitPrice(decimal unitPrice);
        ICollection<Product> GetProductByUnitInStock(int unit);
    }
}
