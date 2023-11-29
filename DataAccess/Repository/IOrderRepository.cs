using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        ICollection<Order> GetOrders();
        Order? GetOrder(int id);
        bool AddOrder(Order order);
        bool UpdateOrder(Order order);
        bool DeleteOrder(int id);
        ICollection<Order> GetOrderByMemberId(int memberId);
    }
}
