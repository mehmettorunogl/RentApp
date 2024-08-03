using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using RentApp.Models;
using RentApp.Utils;
using System.Security.Claims;

namespace RentApp.Areas.Management.Controllers
{
	public class MainPageController : Controller
	{
		private readonly IWebHostEnvironment _environment;
		RentDbContext db = new RentDbContext();
        // GET: MainPageController
        public MainPageController(IWebHostEnvironment environment){
			_environment = environment;
		}
        public ActionResult Index()
		{
			MainPage mainpage = db.MainPages.FirstOrDefault();
			return View(mainpage);
		}

		// GET: MainPageController/Edit/5
		public ActionResult Edit(int id)
		{
			var MainPage = db.MainPages.Find(id);
			if (MainPage == null){
				return RedirectToAction(nameof(Index));
			}
			return View(MainPage);
		}

		//POST: MainPageController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(MainPage model,IFormFile? img1, IFormFile? img2, IFormFile? img3, IFormFile? img4)
		{
			try
			{
                if (ModelState.IsValid)
                {
                    var MainPage = db.MainPages.Find(model.Id);
                    if (MainPage == null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    if (img1 != null && img2 != null && img3 != null && img4 != null )
					{
						await ImageUploader.DeleteImageAsync(_environment, MainPage.ImageUrl1);
						MainPage.ImageUrl1 = await ImageUploader.UploadImageAsync(_environment, img1);
						await ImageUploader.DeleteImageAsync(_environment, MainPage.ImageUrl2);
						MainPage.ImageUrl2 = await ImageUploader.UploadImageAsync(_environment, img2);
						await ImageUploader.DeleteImageAsync(_environment, MainPage.ImageUrl3);
						MainPage.ImageUrl3 = await ImageUploader.UploadImageAsync(_environment, img3);
						await ImageUploader.DeleteImageAsync(_environment, MainPage.ImageUrl4);
						MainPage.ImageUrl4 = await ImageUploader.UploadImageAsync(_environment, img4);
                    }
                    MainPage.Title1 = model.Title1;
                    MainPage.Title2 = model.Title2;
                    MainPage.Description1 = model.Description1;
                    MainPage.Description2 = model.Description2;
                    MainPage.UpdatedDate = model.UpdatedDate;
                    MainPage.UpdatedBy = Convert.ToInt32(User.Claims.FirstOrDefault(r => r.Type == ClaimTypes.NameIdentifier)?.Value);
                    MainPage.Status = model.Status;
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
