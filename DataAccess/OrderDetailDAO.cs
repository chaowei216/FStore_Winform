using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static object lockObject = new object();

        private OrderDetailDAO()
        {
        }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public OrderDetail? GetOrderDetailById(int oId, int pId)
        {
            FstoreContext context = new FstoreContext();
            return context.OrderDetails.FirstOrDefault(od => od.OrderId == oId && od.ProductId == pId);
        }

        public List<OrderDetail> GetOrderDetailByOrId(int oId)
        {
            FstoreContext context = new FstoreContext();
            return context.OrderDetails.Where(od => od.OrderId == oId).ToList();
        }

        public List<OrderDetail> GetOrderDetails()
        {
            FstoreContext context = new FstoreContext();
            return context.OrderDetails.ToList();
        }

        public bool AddNewDetail(OrderDetail detail)
        {
            FstoreContext context = new FstoreContext();
            context.OrderDetails.Add(detail);
            return context.SaveChanges() > 0;
        }
    }
}
