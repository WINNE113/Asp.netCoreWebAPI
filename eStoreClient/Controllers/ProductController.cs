using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eStoreClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly HttpClient Client = null;
        private string ProductApiUrl = "";
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            Client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            Client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "https://localhost:7049/api/Product";
        }
        public async Task<IActionResult> ManagerProduct()
        {
            HttpResponseMessage response = await Client.GetAsync(ProductApiUrl);
            var product = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            List<Product> products = JsonSerializer.Deserialize<List<Product>>(product, options);

           ViewBag.Products = products;  

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            HttpResponseMessage DataResponse = await Client.GetAsync($"https://localhost:7049/api/Product/id?id={id}");
            var productResponse = await DataResponse.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            Product product = JsonSerializer.Deserialize<Product>(productResponse, options);
            

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Product product)
        {
            try
            { // Serialize the model to JSON
                var jsonModel = JsonSerializer.Serialize(product);
                var content = new StringContent(jsonModel, Encoding.UTF8, "application/json");

                var response = await Client.PutAsync($"https://localhost:7049/api/Product/{product.ProductId}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ManagerProduct");
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                HttpResponseMessage DataResponse = await Client.DeleteAsync($"https://localhost:7049/api/Product/id?id={id}");

                if (DataResponse.IsSuccessStatusCode)
                {
                    return Redirect("ManagerProduct");
                }
                else
                {
                    return StatusCode((int)DataResponse.StatusCode);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                // Convert model to json
                var JsonModel = JsonSerializer.Serialize(product);
                var content = new StringContent(JsonModel, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await Client.PostAsync(ProductApiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    return Redirect("ManagerProduct");
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Search(string txtName)
        {
            HttpResponseMessage response = await Client.GetAsync($"https://localhost:7049/api/Product/productName?productName={txtName}");
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            List<Product> products = JsonSerializer.Deserialize<List<Product>>(content, options);

            ViewBag.Products = products;

            return RedirectToAction("ManagerProduct");
        }


    }
}
