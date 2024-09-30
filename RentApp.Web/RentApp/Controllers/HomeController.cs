using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Footer = db.MainPages
                .SingleOrDefault();

            var mainPage = db.MainPages.Include(c=>c.Houses)
                .FirstOrDefault();

            //var mainPages = db.Houses
            //    .ToList();


            return View(mainPage);
        }

        public IActionResult About()
        {
            var about = db.Abouts
                .FirstOrDefault();

            ViewBag.Footer = db.MainPages
                .SingleOrDefault();

            return View(about);
        }
        
        public IActionResult House()
        {
			var houses = db.Houses
                .Include(c => c.Gallery)
                .Include(c => c.Price)
                .Where(x => x.Status && x.IsDeleted == false)
                .ToList();

            ViewBag.Footer = db.MainPages
                .SingleOrDefault();

            return View(houses);
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
