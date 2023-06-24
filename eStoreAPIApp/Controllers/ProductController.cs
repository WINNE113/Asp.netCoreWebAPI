using BusinessObject;
using eStoreAPIApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace eStoreAPIApp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : Controller
    {
        private readonly ProductRepositories productRepositories;
        
        public ProductController()
        {
            this.productRepositories = new ProductRepositories();
        }
        
        // GET: ProductController
        [HttpGet]
        public ActionResult GetProducts()
        {
            return Ok(productRepositories.getProduct());
        }

        // GET: ProductController/Details/5
        [HttpGet("id")]
        public ActionResult GetProduct(int id)
        {
            return Ok(productRepositories.GetProductById(id));
        }

        // GET: ProductController/Details/iphone
        [HttpGet("productName")]
        public ActionResult GetProductByName(string productName)
        {
            return Ok(productRepositories.GetProductByProductName(productName));
        }

        // GET: ProductController/Details/2000
        [HttpGet("unitPrice")]
        public ActionResult GetProductUnitPrice(decimal unitPrice)
        {
            return Ok(productRepositories.GetProductByUnitPrice(unitPrice));
        }

        [HttpPost]
        public IActionResult AddProduct(ProductToPost productToPost)
        {
            try
            {
                Product product = new Product()
                {
                    CategoryId = productToPost.CategoryId,
                    ProductName = productToPost.ProductName,
                    UnitPrice = productToPost.UnitPrice,
                    UnitStock = productToPost.UnitStock,
                    Weight = productToPost.Weight
                };
                productRepositories.SaveProduct(product);
                return Ok(product);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                Product product = productRepositories.GetProductById(id);
                if (product != null)
                {
                    productRepositories.DeleteProduct(id);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateProduct([FromRoute]int id,ProductToUpdate productToUpdate)
        {
            try
            {
                var product = productRepositories.GetProductById(id);
                if(product != null)
                {
                    product.CategoryId = productToUpdate.CategoryId;
                    product.ProductName = productToUpdate.ProductName;
                    product.UnitPrice = productToUpdate.UnitPrice;
                    product.Weight = productToUpdate.Weight;
                    product.UnitStock = productToUpdate.UnitStock;  
                    
                    productRepositories.UpdateProduct(product);
                    return Ok();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return NotFound();
        }
    }

  
}
