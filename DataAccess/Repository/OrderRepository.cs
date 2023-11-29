using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public bool AddOrder(Order order)
        {
            return OrderDAO.Instance.AddOrder(order);
        }

        public bool DeleteOrder(int id)
        {
            return OrderDAO.Instance.DeleteOrder(id);
        }

        public Order? GetOrder(int id)
        {
            return OrderDAO.Instance.GetOrderById(id);
        }

        public Order? GetOrderById(int id)
        {
            return OrderDAO.Instance.GetOrderById(id);
        }

        public ICollection<Order> GetOrderByMemberId(int memberId)
        {
            return OrderDAO.Instance.GetOrders().Where(or => or.MemberId == memberId).ToList();
        }

        public ICollection<Order> GetOrders() => OrderDAO.Instance.GetOrders();

        public bool UpdateOrder(Order order)
        {
            return OrderDAO.Instance.UpdateOrder(order);
        }
    }
}
