using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        public static List<OrderDetail> GetOrderDetails()
        {
            var orderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new EStoreDbContext())
                {
                    orderDetails = context.orderDetails.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }
        public static void SaveOrderDetail(OrderDetail member)
        {
            try
            {
                using (var context = new EStoreDbContext())
                {
                    context.orderDetails.Add(member);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
