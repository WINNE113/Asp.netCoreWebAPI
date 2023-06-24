using BusinessObject;

namespace DataAccess
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var products = new List<Product>();
            try
            {
                using (var context = new EStoreDbContext())
                {
                    products = context.products.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
        public static Product FindProductById(int ProductId)
        {
            var product = new Product();
            try
            {
                using (var context = new EStoreDbContext())
                {
                    product = context.products.SingleOrDefault(x => x.ProductId == ProductId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }
        public static List<Product> FindProductByName(string ProductName)
        {
            var product = new List<Product>();
            try
            {
                using (var context = new EStoreDbContext())
                {
                    if (context != null)
                    {
                        product = context.products.Where(p => p.ProductName.Contains(ProductName)).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }
        public static List<Product> FindProductByUnitPrice(decimal UnitPrice)
        {
            var product = new List<Product>();
            try
            {
                using (var context = new EStoreDbContext())
                {
                    product = context.products.Where(x => x.UnitPrice == UnitPrice).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public static void UpdateProduct(Product product)
        {
            try
            {
                using (var context = new EStoreDbContext())
                {
                    context.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SaveProduct(Product product)
        {
            try
            {
                using (var context = new EStoreDbContext())
                {
                    context.products.Add(product);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteProduct(int ProductId)
        {
            var product = new Product();
            try
            {
                using (var context = new EStoreDbContext())
                {
                    product = context.products.SingleOrDefault(x => x.ProductId == ProductId);
                    context.products.Remove(product);
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
