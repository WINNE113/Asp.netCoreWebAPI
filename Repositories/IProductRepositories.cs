using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductRepositories
    {
        List<Product> getProduct();
        Product GetProductById(int id);
        List<Product> GetProductByProductName(string productName);
        List<Product> GetProductByUnitPrice(decimal unitPrice);
        void UpdateProduct(Product member);
        void DeleteProduct(int id);
        void SaveProduct(Product member);
    }
}
