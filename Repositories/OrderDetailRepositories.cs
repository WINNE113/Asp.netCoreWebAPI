using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderDetailRepositories : IOrderDetailRepositories
    {
        public List<OrderDetail> GetOrderDetails()
        {
            return OrderDetailDAO.GetOrderDetails();    
        }

        public void SaveOrderDetail(OrderDetail orderDetail)
        {
            OrderDetailDAO.SaveOrderDetail(orderDetail); 
        }
    }
}
