using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Hosting;
using RentApp.Models;
using RentApp.Utils;
using System;
using System.Security.Claims;

namespace RentApp.Areas.Management.Controllers
{

	public class MainPageController : Controller
	{
		private readonly IWebHostEnvironment _environment;
		RentDbContext db = new RentDbContext();
        // GET: MainPageController
        public MainPageController(IWebHostEnvironment environment)
		{
			_environment = environment;
		}
        public ActionResult Index()
		{
			MainPage mainpage = db.MainPages
				.FirstOrDefault();

			return View(mainpage);
		}
		[Authorize(Roles = "SuperAdmin, Developer")]
		// GET: MainPageController/Edit/5
		public ActionResult Edit(int id)
		{
			var MainPage = db.MainPages
				.Find(id);

			if (MainPage == null){
				return RedirectToAction(nameof(Index));
			}
			return View(MainPage);
		}

		//POST: MainPageController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MainPage model, IFormFile? img1, IFormFile? img2, IFormFile? img3, IFormFile? img4)
        {
            try
            {
                var mainPage = await db.MainPages.FindAsync(model.Id);

                if (mainPage == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                // Sadece img1 değiştiyse güncelle
                if (img1 != null)
                {
                    await ImageUploader.DeleteImageAsync(_environment, mainPage.ImageUrl1);
                    mainPage.ImageUrl1 = await ImageUploader.UploadImageAsync(_environment, img1);
                }

                // Sadece img2 değiştiyse güncelle
                if (img2 != null)
                {
                    await ImageUploader.DeleteImageAsync(_environment, mainPage.ImageUrl2);
                    mainPage.ImageUrl2 = await ImageUploader.UploadImageAsync(_environment, img2);
                }

                // Sadece img3 değiştiyse güncelle
                if (img3 != null)
                {
                    await ImageUploader.DeleteImageAsync(_environment, mainPage.ImageUrl3);
                    mainPage.ImageUrl3 = await ImageUploader.UploadImageAsync(_environment, img3);
                }

                // Sadece img4 değiştiyse güncelle
                if (img4 != null)
                {
                    await ImageUploader.DeleteImageAsync(_environment, mainPage.ImageUrl4);
                    mainPage.ImageUrl4 = await ImageUploader.UploadImageAsync(_environment, img4);
                }

                // Diğer alanları güncelle
                mainPage.Title1 = model.Title1;
                mainPage.Title2 = model.Title2;
                mainPage.Description1 = model.Description1;
                mainPage.Description2 = model.Description2;
                mainPage.UpdatedDate = DateTime.UtcNow;
                mainPage.FooterAddress = model.FooterAddress;
                mainPage.FooterPhone = model.FooterPhone;
                mainPage.FooterEmail = model.FooterEmail;
                mainPage.FacebookUrl = model.FacebookUrl;
                mainPage.TwitterUrl = model.TwitterUrl;
                mainPage.LinkedInUrl = model.LinkedInUrl;
                mainPage.YoutubeUrl = model.YoutubeUrl;
                mainPage.UpdatedBy = Convert.ToInt32(User.Claims.FirstOrDefault(r => r.Type == ClaimTypes.NameIdentifier)?.Value);
                mainPage.Status = model.Status;

                await db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Hata durumunda, hata mesajını modelde saklayarak kullanıcıya geri bildirim verebilirsiniz
                ModelState.AddModelError("", $"Güncelleme sırasında bir hata oluştu: {ex.Message}");
                return View(model);
            }
        }

    }
}
