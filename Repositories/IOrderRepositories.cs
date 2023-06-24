using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderRepositories
    {
        List<Order> getOrder();
        Order GetOrderById(int id);
        void UpdateOrder(Order member);
        void DeleteOrder(int id);
        void SaveOrder(Order member);
    }
}
