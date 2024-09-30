using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Cms;
using RentApp.Areas.Management.Models;
using RentApp.Models;
using System.Linq;

namespace RentApp.Areas.Management.Controllers
{
	[Authorize]
	public class DashboardController : Controller
    {
		
        RentDbContext db = new RentDbContext();
		public IActionResult Index()
		{
			return View();
		}

		[Authorize(Roles = "SuperAdmin, Developer")]
		public IActionResult Analytics(int id)
        {
			var rent = db.Rents.Include(c => c.User).Include(c => c.Gallery).ThenInclude(c => c.House).Where(c => c.Status && c.IsDeleted == false).OrderBy(r => r.CheckinDate).ToList();
			return View(rent);
		}

		[Authorize(Roles = "SuperAdmin, Developer")]
		public IActionResult Sales()
		{
			DashboardViewModel model = new DashboardViewModel();

			model.UserCount = db.Users.Count(r =>
			r.Role == RentApp.Models.Role.User &&
			r.IsDeleted == false &&
			r.Status);

			model.OwnerCount = db.Accounts.Count(r =>
			r.Role == RentApp.Models.Role.Admin &&
			r.IsDeleted == false &&
			r.Status);

			model.ManagerCount = db.Accounts.Count(r =>
			r.Role == RentApp.Models.Role.SuperAdmin &&
			r.IsDeleted == false &&
			r.Status);

			model.Contracts = db.Rents.Count(c =>
			c.Status &&
			c.IsDeleted == false);

			model.MonthlyIncome = db.Rents
			.Where(x =>
			x.CreatedDate.Year == DateTime.Now.Year &&
			x.CreatedDate.Month == DateTime.Now.Month &&
			x.Status &&
			x.IsDeleted == false)
			.Sum(s =>
			s.TotalPrice
			);

			model.DailyIncome = db.Rents
			.Where(x =>
			x.CreatedDate.Year == DateTime.Now.Year &&
			x.CreatedDate.Month == DateTime.Now.Month &&
			x.CreatedDate.Day == DateTime.Now.Day &&
			x.Status &&
			x.IsDeleted == false)
			.Sum(s =>
			s.TotalPrice);

			return View(model);
		}

		[Authorize(Roles = "SuperAdmin, Developer")]
		public IActionResult UserInfo(DashboardViewModel model)
		{
			model.LastCreatedUser = db.Accounts
			.Where(c => c.Role != Role.Developer)
			.OrderByDescending(o => o.CreatedDate)
			.FirstOrDefault();

			model.LastCreatedUsers = db.Accounts
			.Where(c => c.Role != Role.Developer)
			.OrderByDescending(o => o.CreatedDate).ToList();

			return View(model);
		}

	}
}
