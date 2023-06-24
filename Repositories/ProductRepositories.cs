using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepositories:IProductRepositories
    {
        public void DeleteProduct(int id) => ProductDAO.DeleteProduct(id);

        public List<Product> getProduct() => ProductDAO.GetProducts();

        public Product GetProductById(int id) => ProductDAO.FindProductById(id);

        public List<Product> GetProductByProductName(string ProductName) => ProductDAO.FindProductByName(ProductName);

        public List<Product> GetProductByUnitPrice(Decimal UnitPrice) => ProductDAO.FindProductByUnitPrice(UnitPrice);

        public void SaveProduct(Product product) => ProductDAO.SaveProduct(product);

        public void UpdateProduct(Product product) => ProductDAO.UpdateProduct(product);
    }
}
