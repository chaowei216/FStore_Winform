
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO? instance = null;
        private static object lockObject = new object();

        private ProductDAO()
        {
        }
        public static ProductDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public Product? GetProductById(int id)
        {
            FstoreContext context = new FstoreContext();
            return context.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public Product? GetProductByName(string name)
        {
            FstoreContext context = new FstoreContext();
            return context.Products.FirstOrDefault(p => p.ProductName == name);
        }

        public List<Product> GetProducts()
        {
            FstoreContext context = new FstoreContext();
            return context.Products.ToList();
        }

        public bool AddProduct(Product product)
        {
            FstoreContext context = new FstoreContext();
            context.Products.Add(product);
            return context.SaveChanges() > 0;
        }

        public bool UpdateProduct(Product product)
        {
            var pro = GetProductById(product.ProductId);
            if(pro != null)
            {
                pro.CategoryId = product.CategoryId;
                pro.ProductName = product.ProductName;
                pro.Weight = product.Weight;
                pro.UnitPrice = product.UnitPrice;
                pro.UnitsInStock = product.UnitsInStock;
                FstoreContext context = new FstoreContext();
                context.Products.Update(pro);
                return context.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeleteProduct(int id)
        {
            if (GetProductById(id) == null) return false;
            var pro = GetProductById(id);
            FstoreContext context = new FstoreContext();
            context.Products.Remove(pro);
            return context.SaveChanges() > 0;
        }
    }
}
