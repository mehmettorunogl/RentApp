using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentApp.Models;
using RentApp.Utils;
using System.Security.Claims;

namespace RentApp.Areas.Management.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        //dependency injection
        private readonly IWebHostEnvironment _environment;
        RentDbContext db = new RentDbContext();
        // GET: AboutController
        public AboutController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public ActionResult Index()
        {
            var about = db.Abouts
                .FirstOrDefault();

            return View(about);
        }
		[Authorize(Roles = "SuperAdmin, Developer")]
		// GET: AboutController/Edit/5
		public ActionResult Edit(int id)
        {
            var about = db.Abouts
                .Find(id);

            if (about == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(about);
        }

        // POST: AboutController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(About model, IFormFile? img)
        {
            try{
                if (ModelState.IsValid) {
                    var about = db.Abouts
                        .Find(model.Id);

                    if (about == null){
                        return RedirectToAction(nameof(Index));
                    }

					about.Title = model.Title;
					about.Description = model.Description;

					if (img != null){
                        await ImageUploader.DeleteImageAsync(_environment, about.ImageUrl);
                        about.ImageUrl = await ImageUploader.UploadImageAsync(_environment, img);
                    }

                    about.UpdatedDate = model.UpdatedDate;
                    about.UpdatedBy = Convert.ToInt32(User.Claims.FirstOrDefault(r => r.Type == ClaimTypes.NameIdentifier)?.Value);
                    about.Status = model.Status;

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
