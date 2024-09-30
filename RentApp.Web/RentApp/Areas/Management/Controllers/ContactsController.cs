using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentApp.Models;
using System.Security.Claims;

namespace RentApp.Areas.Management.Controllers
{
	[Authorize]
	public class ContactsController : Controller
    {
		RentDbContext db = new RentDbContext();
        // GET: ContactsController
        public ActionResult Index()
        {
			var map = db.Contacts.FirstOrDefault();
			var contacts = db.Contacts.ToList();
            return View(contacts);
        }

		[Authorize(Roles = "SuperAdmin, Developer")]
		// GET: HouseController/Edit/5
		public ActionResult Edit(int id)
		{
			var map = db.Contacts
				.FirstOrDefault(c=>c.Id== id);
			if (map == null)
			{
				return RedirectToAction(nameof(Index));
			}
			return View(map);

		}
		// POST: HouseController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Contact model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					var editMap = db.Contacts.Find(model.Id);
					if (editMap == null)
					{
						return RedirectToAction(nameof(Index));
					}
					editMap.Map = model.Map;
					editMap.UpdatedBy = Convert.ToInt32(User.Claims.FirstOrDefault(r => r.Type == ClaimTypes.NameIdentifier)?.Value);
					editMap.UpdatedDate = DateTime.Now;
					db.SaveChanges();
					return RedirectToAction(nameof(Index));
				}
				return View(model);
			}
			catch
			{
				return View(model);
			}
		}
	}
}
