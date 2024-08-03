using Microsoft.AspNetCore.Mvc;
using RentApp.Models;
using System.Diagnostics;

namespace RentApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        RentDbContext db = new RentDbContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var mainpage = db.MainPages.FirstOrDefault();
            return View(mainpage);
        }

        public IActionResult About()
        {
            var about = db.Abouts.FirstOrDefault();
            return View(about);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
