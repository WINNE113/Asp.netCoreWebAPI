using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace eStoreClient.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
 
        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
       
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ManagerProduct()
        {

            return RedirectToAction("ManagerProduct", "Product");
        }
    }
}
