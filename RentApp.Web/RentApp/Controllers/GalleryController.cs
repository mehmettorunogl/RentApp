using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentApp.Models;
using RentApp.Models.ContractViewModels;
using RentApp.Utils;
using System.Security.Claims;

namespace RentApp.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        RentDbContext db = new RentDbContext();

        public GalleryController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public IActionResult Index(int id)
        {
            ViewBag.Footer = db.MainPages
                .SingleOrDefault();

            var house = db.Houses
                .Include(h => h.Gallery)
                .Include(h => h.Price)
                .FirstOrDefault(m => m.Id == id);

            if (house == null)
            {
                return RedirectToAction("Index");
            }
            return View(house);
        }
    }
}
