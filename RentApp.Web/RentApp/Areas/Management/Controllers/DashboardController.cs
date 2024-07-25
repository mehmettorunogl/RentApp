using Microsoft.AspNetCore.Mvc;

namespace RentApp.Areas.Management.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
