using BusinessObject;
using eStoreAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace eStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepositories repositories = new ProductRepositories(); 
        // GET: ProductController
        [HttpGet]
        public ActionResult GetProducts()
        {
            return Ok(repositories.getProduct()) ;
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductToCreate productToCreate)
        {
            Product product = new Product()
            {
                CategoryId = productToCreate.CategoryId,
                ProductName = productToCreate.ProductName,
                Weight = productToCreate.Weight,
                UnitPrice = productToCreate.UnitPrice,
                UnitStock = productToCreate.UnitStock
            };
            try
            {
                repositories.SaveProduct(product);
                return Ok(product);
            }
            catch
            {
                return View();
            }
        }

       
    }
}
