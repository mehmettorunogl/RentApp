using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentApp.Models;

namespace RentApp.Controllers
{
	public class ContactController : Controller
	{
		RentDbContext db = new RentDbContext();
		// GET: ContactController
		public ActionResult Index()
		{
			return View();
		}
		// GET: ContactController/Create
		public ActionResult Create()
		{
			var map = db.Contacts.FirstOrDefault(c=>c.Id==5);
			ViewBag.Footer = db.MainPages
				.SingleOrDefault();
			var contact = new Contact() 
			{
				Map = map.Map,
			};
			return View(contact);
		}

		// POST: ContactController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Contact model)
		{
			try
			{
				var map = db.Contacts.SingleOrDefault(c=>c.Id==5);
				var contact = new Contact
				{
					Name = model.Name,
					Email = model.Email,
					PhoneNumber = model.PhoneNumber,
					Message = model.Message,
					Map = model.Map = map.Map,
					Title = model.Title = map.Title,
				};
				model.Status = true;
					model.CreatedDate = DateTime.Now;
					model.CreatedBy = 0;
					model.IsDeleted = false;
					db.Contacts.Add(model);
					db.SaveChanges();
					return RedirectToAction(nameof(Create));
			}
			catch
			{
				return View();
			}
		}
	}
}
