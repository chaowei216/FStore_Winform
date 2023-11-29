using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public bool AddNew(OrderDetail orderDetail)
        {
            return OrderDetailDAO.Instance.AddNewDetail(orderDetail);
        }

        public List<OrderDetail> GetOrderDetailByOrId(int orderId)
        {
            return OrderDetailDAO.Instance.GetOrderDetailByOrId(orderId);
        }
    }
}
