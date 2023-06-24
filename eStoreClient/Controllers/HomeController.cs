using BusinessObject;
using eStoreClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eStoreClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient Client = null;
        private string ProductApiUrl = "";
        private AdminCredentials adminCredentials;

        public HomeController(ILogger<HomeController> logger, IOptions<AdminCredentials> adminCredentials)
        {
            _logger = logger;
            Client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            Client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "https://localhost:7049/api/Product";
            // Info Admin
            this.adminCredentials = adminCredentials.Value;
        }
        public async Task<IActionResult> Index()
        { 
            HttpResponseMessage response = await Client.GetAsync(ProductApiUrl);
            string srtData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            List<Product> products = JsonSerializer.Deserialize<List<Product>>(srtData, options);

            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email, string passWord)
        {
           if(adminCredentials.Email.Equals(Email) && adminCredentials.Password.Equals(passWord))
            {
                return RedirectToAction("Index","Admin");
            }

            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}