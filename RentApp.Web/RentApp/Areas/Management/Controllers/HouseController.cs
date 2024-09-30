using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentApp.Models;
using RentApp.Utils;
using System.Security.Claims;
using RentApp.Areas.Management.Models;
using Microsoft.AspNetCore.Authorization;
namespace RentApp.Areas.Management.Controllers
{
	[Authorize]
	public class HouseController : Controller
    {
		//dependency injection
		private readonly IWebHostEnvironment _environment;
		RentDbContext db = new RentDbContext();
        

		public HouseController(IWebHostEnvironment environment)
		{
			_environment = environment;
		}

		// GET: HouseController
		public ActionResult Index()
        {
            var houses = db.Houses
				.Include(c=>c.Gallery)
				.Include(c => c.Price)
				.Where(x=>x.IsDeleted == false)
				.ToList();

            return View(houses);
		}

        // GET: HouseController/Details/5
        public ActionResult Details(int id)
        {
			var house = db.Houses
				.Include(g => g.Gallery)
				.Include(p => p.Price)
				.FirstOrDefault(m => m.Id == id);

			if (house == null)
			{
				return RedirectToAction("Index");
			}
			return View(house);
        }

        // GET: HouseController/Create
        public ActionResult Create()
        {
            var viewModel = new HouseGalleryViewModels();
            return View(viewModel);
        }

        // POST: HouseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HouseGalleryViewModels viewModel, IFormFile img, IFormFile img1, IFormFile img2, IFormFile img3, IFormFile img4, IFormFile img5, IFormFile img6, IFormFile img7, IFormFile img8)
        {
			try
			{
				if (ModelState.IsValid)
				{
					var mainPage = db.MainPages.FirstOrDefault();
					var house = new House
					{
						Title = viewModel.Title,
						Description = viewModel.Description,
						Address = viewModel.Address,
						AdultCount = viewModel.AdultCount,
						ChildCount = viewModel.ChildCount,
						RoomCount = viewModel.RoomCount,
						BathCount = viewModel.BathCount,
						Floors = viewModel.Floors,
						Email = viewModel.Email,
						Country = viewModel.Country,
						City = viewModel.City,
						District = viewModel.District,
						ImageUrl = viewModel.ImageUrl,
						MainPageId = mainPage.Id
					};
					if (img != null)
					{
						house.ImageUrl = await ImageUploader.UploadImageAsync(_environment, img);
					}
					db.Houses.Add(house);
					db.SaveChanges();

					var price = new Price
					{
						HouseId = house.Id,
						Day = viewModel.Day,
						Cost = viewModel.Cost,
						CleaningPrice = viewModel.CleaningPrice,
						Prices = (viewModel.Cost + viewModel.CleaningPrice),
						
					};

					db.Prices.Add(price);

					var gallery = new Gallery
					{
						HouseId = house.Id,
						ImageUrl1 = viewModel.ImageUrl1,
						ImageUrl2 = viewModel.ImageUrl2,
						ImageUrl3 = viewModel.ImageUrl3,
						ImageUrl4 = viewModel.ImageUrl4,
						ImageUrl5 = viewModel.ImageUrl5,
						ImageUrl6 = viewModel.ImageUrl6,
						ImageUrl7 = viewModel.ImageUrl7,
						ImageUrl8 = viewModel.ImageUrl8
					};

					if (img1 != null)
					{
						gallery.ImageUrl1 = await ImageUploader.UploadImageAsync(_environment, img1);
					}
					if (img2 != null)
					{
						gallery.ImageUrl2 = await ImageUploader.UploadImageAsync(_environment, img2);
					}
					if (img3 != null)
					{
						gallery.ImageUrl3 = await ImageUploader.UploadImageAsync(_environment, img3);
					}
					if (img4 != null)
					{
						gallery.ImageUrl4 = await ImageUploader.UploadImageAsync(_environment, img4);
					}
					if (img5 != null)
					{
						gallery.ImageUrl5 = await ImageUploader.UploadImageAsync(_environment, img5);
					}
					if (img6 != null)
					{
						gallery.ImageUrl6 = await ImageUploader.UploadImageAsync(_environment, img6);
					}
					if (img7 != null)
					{
						gallery.ImageUrl7 = await ImageUploader.UploadImageAsync(_environment, img7);
					}
					if (img8 != null)
					{
						gallery.ImageUrl8 = await ImageUploader.UploadImageAsync(_environment, img8);
					}
                    
					house.Status = true;
					house.IsDeleted = false;
					house.CreatedDate = DateTime.Now;
					house.CreatedBy = Convert.ToInt32(User.Claims.FirstOrDefault(r => r.Type == ClaimTypes.NameIdentifier)?.Value);
					db.Galleries.Add(gallery);
					db.SaveChanges();

					return RedirectToAction(nameof(Index));
				}
				return View(viewModel);
			}

			catch
			{
				return View(viewModel);
			}
		}
		[Authorize(Roles = "SuperAdmin, Developer")]
		// GET: HouseController/Edit/5
		public async Task<ActionResult> Edit(int id)
        {
			var house = db.Houses
				.Include(h => h.Gallery)
				.Include(p => p.Price)
			    .FirstOrDefault(m => m.Id == id);
            var price = await db.Prices
                    .Include(h => h.House)
                    .FirstOrDefaultAsync(m => m.HouseId == id);

            if (house == null)
			{
				return RedirectToAction(nameof(Index));
			}
			var viewModel = new HouseGalleryViewModels
			{
				Title = house.Title,
				Description = house.Description,
				Address = house.Address,
				AdultCount = house.AdultCount,
				ChildCount = house.ChildCount,
				RoomCount = house.RoomCount,
				BathCount = house.BathCount,
				Floors = house.Floors,
				Email = house.Email,
				Country = house.Country,
				City = house.City,
				District = house.District,
                Day = price.Day,
                CleaningPrice = price.CleaningPrice,
                Cost = house.Price.FirstOrDefault()?.Cost ?? 0,
				ImageUrl = house.ImageUrl,
				ImageUrl1 = house.Gallery.FirstOrDefault()?.ImageUrl1,
				ImageUrl2 = house.Gallery.FirstOrDefault()?.ImageUrl2,
				ImageUrl3 = house.Gallery.FirstOrDefault()?.ImageUrl3,
				ImageUrl4 = house.Gallery.FirstOrDefault()?.ImageUrl4,
				ImageUrl5 = house.Gallery.FirstOrDefault()?.ImageUrl5,
				ImageUrl6 = house.Gallery.FirstOrDefault()?.ImageUrl6,
				ImageUrl7 = house.Gallery.FirstOrDefault()?.ImageUrl7,
				ImageUrl8 = house.Gallery.FirstOrDefault()?.ImageUrl8,
				Status = house.Status,
				UpdatedBy = Convert.ToInt32(User.Claims.FirstOrDefault(r => r.Type == ClaimTypes.NameIdentifier)?.Value),
				UpdatedDate = house.UpdatedDate,
			};
			return View(viewModel);

		}

        // POST: HouseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(HouseGalleryViewModels viewModel,int id, IFormFile img, IFormFile img1, IFormFile img2, IFormFile img3, IFormFile img4, IFormFile img5, IFormFile img6, IFormFile img7, IFormFile img8)
        {
            try
            {
                var house = await db.Houses
                    .Include(h => h.Gallery)
                    .Include(p => p.Price)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (house == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                house.Title = viewModel.Title ?? house.Title;
                house.Description = viewModel.Description ?? house.Description;
                house.Address = viewModel.Address ?? house.Address;
                house.AdultCount = viewModel.AdultCount != 0 ? viewModel.AdultCount : house.AdultCount;
                house.ChildCount = viewModel.ChildCount != 0 ? viewModel.ChildCount : house.ChildCount;
                house.RoomCount = viewModel.RoomCount != 0 ? viewModel.RoomCount : house.RoomCount;
                house.BathCount = viewModel.BathCount != 0 ? viewModel.BathCount : house.BathCount;
                house.Floors = viewModel.Floors ??  house.Floors;
                house.Email = viewModel.Email ?? house.Email;
                house.Country = viewModel.Country ?? house.Country;
                house.City = viewModel.City ?? house.City;
                house.District = viewModel.District ?? house.District;
                house.Status = viewModel.Status;

                if (!string.IsNullOrEmpty(viewModel.ImageUrl))
                {
                    house.ImageUrl = viewModel.ImageUrl;
                }
                if (img != null)
                {
                    house.ImageUrl = img != null ? await ImageUploader.UploadImageAsync(_environment, img) : viewModel.ImageUrl1;
                }

                var gallery = house.Gallery
					.FirstOrDefault();

                if (gallery != null)
                {
                    gallery.HouseId = house.Id;
               
                    if (img1 != null)
                    {
                        gallery.ImageUrl1 = img1 != null ? await ImageUploader.UploadImageAsync(_environment, img1) : gallery.ImageUrl1;
                    }
                    if (img2 != null)
                    {
                        gallery.ImageUrl2 = img2 != null ? await ImageUploader.UploadImageAsync(_environment, img2) : gallery.ImageUrl2;
                    }
                    if (img3 != null)
                    {
                        gallery.ImageUrl3 = img3 != null ? await ImageUploader.UploadImageAsync(_environment, img3) : gallery.ImageUrl3;
                    }
                    if (img4 != null)
                    {
                        gallery.ImageUrl4 = img4 != null ? await ImageUploader.UploadImageAsync(_environment, img4) : gallery.ImageUrl4;
                    }
                    if (img5 != null)
                    {
                        gallery.ImageUrl5 = img5 != null ? await ImageUploader.UploadImageAsync(_environment, img5) : gallery.ImageUrl5;
                    }
                    if (img6 != null)
                    {
                        gallery.ImageUrl6 = img6 != null ? await ImageUploader.UploadImageAsync(_environment, img6) : gallery.ImageUrl6;
                    }
                    if (img7 != null)
                    {
                        gallery.ImageUrl7 = img7 != null ? await ImageUploader.UploadImageAsync(_environment, img7) : gallery.ImageUrl7;
                    }
                    if (img8 != null)
                    {
                        gallery.ImageUrl8 = img8 != null ? await ImageUploader.UploadImageAsync(_environment, img8) : gallery.ImageUrl8;
                    }
                }
                var price = house.Price
					.FirstOrDefault();

				if (price != null)
				{
				    price.HouseId = house.Id;
				    price.Day = viewModel.Day != 0 ? viewModel.Day : price.Day;
				    price.CleaningPrice = viewModel.CleaningPrice != 0 ? viewModel.CleaningPrice : price.CleaningPrice;
				    price.Cost = viewModel.Cost != 0 ? viewModel.Cost : price.Cost;
					price.Prices = (viewModel.Cost + viewModel.CleaningPrice);
				}

				house.UpdatedBy = Convert.ToInt32(User.Claims.FirstOrDefault(r => r.Type == ClaimTypes.NameIdentifier)?.Value);
				house.UpdatedDate = DateTime.Now;

				await db.SaveChangesAsync();

				return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(viewModel);
            }
        }
		[Authorize(Roles = "SuperAdmin, Developer")]
		// GET: HouseController/Delete/5
		public ActionResult Delete(int id)
        {

			var house = db.Houses
					.Include(h => h.Gallery).Include(p => p.Price)
					.FirstOrDefault(m => m.Id == id);

			if (house == null)
			{
				return RedirectToAction(nameof(Index));
			}
			return View(house);
		}

		// POST: HouseController/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
				var house = db.Houses
					.Include(h => h.Price)
					.Include(p => p.Gallery)
					.FirstOrDefault(m => m.Id == id);

				if (house == null)
				{
					return RedirectToAction(nameof(Index));
				}
				var viewModel = new HouseGalleryViewModels
				{
					HouseId = house.Id,
					Status = house.Status,
					IsDeleted = house.IsDeleted,
					UpdatedBy = house.UpdatedBy,
					UpdatedDate = house.UpdatedDate,
				};

				house.IsDeleted = true;
				house.DeletedDate = DateTime.Now;
				house.UpdatedBy = Convert.ToInt32(User.Claims.FirstOrDefault(r => r.Type == ClaimTypes.NameIdentifier)?.Value);

				db.SaveChanges();

				return RedirectToAction(nameof(Index));
            }
            catch
            {
				return RedirectToAction(nameof(Index));
			}
        }
    }
}
