using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        bool AddNew(OrderDetail orderDetail);
        List<OrderDetail> GetOrderDetailByOrId(int orderId);
    }
}
