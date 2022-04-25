using Microsoft.AspNetCore.Mvc;
using StoreWebApplication.Models;
using System.Diagnostics;

namespace StoreWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Category()
        {
            return RedirectToAction("Index", "Categories");
        }
        public IActionResult Firms()
        {
            return RedirectToAction("Index", "Firms");
        }
        public IActionResult Customers()
        {
            return RedirectToAction("Index", "Firms");
        }
        public IActionResult Orders()
        {
            return RedirectToAction("Index", "Orders");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}