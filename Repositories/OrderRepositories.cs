using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepositories : IOrderRepositories
    {
        public void DeleteOrder(int id) => OrderDAO.DeleteOrder(id);
        public List<Order> getOrder() => OrderDAO.GetOrders();
        public Order GetOrderById(int id) => OrderDAO.FindOrderById(id);
        public void SaveOrder(Order member) => OrderDAO.SaveOrder(member);
        public void UpdateOrder(Order member) => OrderDAO.UpdateOrder(member);
    }
}
