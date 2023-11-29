using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public bool AddProduct(Product product)
        {
            return ProductDAO.Instance.AddProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return ProductDAO.Instance.DeleteProduct(id);
        }

        public Product? GetProductById(int id)
        {
            return ProductDAO.Instance.GetProductById(id);
        }

        public Product? GetProductByName(string name)
        {
            return ProductDAO.Instance.GetProductByName(name);
        }

        public ICollection<Product> GetProductByUnitInStock(int unit)
        {
            return ProductDAO.Instance.GetProducts().Where(p => p.UnitsInStock == unit).ToList();
        }

        public ICollection<Product> GetProductByUnitPrice(decimal unitPrice)
        {
            return ProductDAO.Instance.GetProducts().Where(p => p.UnitPrice == unitPrice).ToList();
        }

        public ICollection<Product> GetProducts()
        {
             return ProductDAO.Instance.GetProducts();
        }

        public bool UpdateProduct(Product product)
        {
            return ProductDAO.Instance.UpdateProduct(product);
        }
    }
}
