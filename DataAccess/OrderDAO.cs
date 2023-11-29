using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static object lockObject = new object();

        private OrderDAO() {}
        public static OrderDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public Order? GetOrderById(int id)
        {
            FstoreContext context = new FstoreContext();
            return context.Orders.FirstOrDefault(order => order.OrderId == id);
        }

        public List<Order> GetOrders()
        {
            FstoreContext context = new FstoreContext();
            return context.Orders.ToList();
        }

        public bool AddOrder(Order order)
        {
            var or = GetOrderById(order.OrderId);
            if (or == null)
            {
                FstoreContext context = new FstoreContext();
                context.Orders.Add(order);
                return context.SaveChanges() > 0;
            }
            return false;
        }

        public bool UpdateOrder(Order order)
        {
            var or = GetOrderById(order.OrderId);
            if (or != null)
            {
                FstoreContext context = new FstoreContext();
                or.RequiredDate = order.RequiredDate;
                or.ShippedDate = order.ShippedDate;
                or.Freight = order.Freight;
                context.Orders.Update(or);
                return context.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeleteOrder(int id)
        {
            var order = GetOrderById(id);
            if (order != null)
            {
                FstoreContext context = new FstoreContext();
                context.Orders.Remove(order);
                return context.SaveChanges() > 0;
            }
            return false;
        }
    }
}
