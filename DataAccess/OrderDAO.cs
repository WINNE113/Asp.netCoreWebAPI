using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        public static List<Order> GetOrders()
        {
            var orders = new List<Order>();
            try
            {
                using (var context = new EStoreDbContext())
                {
                    orders = context.orders.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
        public static Order FindOrderById(int OrderId)
        {
            var order = new Order();
            try
            {
                using (var context = new EStoreDbContext())
                {
                    order = context.orders.SingleOrDefault(x => x.OrderId == OrderId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }
        public static void UpdateOrder(Order order)
        {
            try
            {
                using (var context = new EStoreDbContext())
                {
                    context.Entry<Order>(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SaveOrder(Order order)
        {
            try
            {
                using (var context = new EStoreDbContext())
                {
                    context.orders.Add(order);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteOrder(int OrderId)
        {
            var order = new Order();
            try
            {
                using (var context = new EStoreDbContext())
                {
                    order = context.orders.SingleOrDefault(x => x.OrderId == OrderId);
                    context.orders.Remove(order);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
