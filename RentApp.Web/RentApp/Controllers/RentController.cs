using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentApp.Helpers;
using RentApp.Models;
using RentApp.Models.ContractViewModels;
using RentApp.Utils;
using System.Security.Claims;

namespace RentApp.Controllers
{
    public class RentController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        RentDbContext db = new RentDbContext();


        public RentController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        // GET: RentController
        public ActionResult Index()
        {
            ViewBag.Footer = db.MainPages
                .SingleOrDefault();

            return View();
        }

        // GET: RentController/Create
        public async Task<ActionResult> Contract(int id)
        {
            ViewBag.Footer = db.MainPages
                .SingleOrDefault();

            var price = await db.Prices
                .Include(h => h.House)
                .FirstOrDefaultAsync(m => m.HouseId == id);

            var model = new ContractViewModels
            {
                CleaningPrice = price.CleaningPrice,
                Cost = price.Cost,
                TotalPrice = price.CleaningPrice+price.Cost,
                Day = price.Day,
            };
            return View(model);
        }

        // POST: RentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contract(ContractViewModels model, IFormFile img, int id)
        {
            try
            {
                ViewBag.Footer = db.MainPages
                    .SingleOrDefault();

                var gallery = db.Galleries
                    .Include(h => h.House)
                    .FirstOrDefault(m => m.HouseId == id);

                var price = await db.Prices
                    .Include(h => h.House)
                    .FirstOrDefaultAsync(m => m.HouseId == id);

                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone,
                    IdentityNumber = model.IdentityNumber,
                    Address = model.Address,
                    BirthDate = model.BirthDate,
                    ImageUrl = model.ImageUrl,
                    Status = model.Status == true,
                    CreatedDate = model.CreatedDate,
                    CreatedBy = model.CreatedBy,
                    IsDeleted = model.IsDeleted,

                };
                if (img != null)
                {
                    user.ImageUrl = await ImageUploader.UploadImageAsync(_environment, img);
                }
                user.Status = true;
                user.IsDeleted = false;
                user.CreatedDate = DateTime.Now;
                user.CreatedBy = Convert.ToInt32(User.Claims.FirstOrDefault(r => r.Type == ClaimTypes.NameIdentifier)?.Value);

                db.Users.Add(user);
                db.SaveChanges();

                
                var rent = new Rent
                {
                    Id = model.RentId,
                    UserId = user.Id,
                    TotalPrice = price.Prices,
                    CheckinDate = model.CheckinDate,
                    CheckoutDate = model.CheckoutDate,
                    PrePaymentPrice = model.PrePaymentPrice,
                    GalleryId = gallery.Id,
                };

                DateTime newStartDate = model.CheckinDate;
                DateTime newEndDate = model.CheckoutDate;
                int galleryId = gallery.Id;

                if (newStartDate < DateTime.Now || newEndDate < DateTime.Now)
                {
					
					ModelState.AddModelError(string.Empty, "Tarih aralığı geçmişte olamaz.");

					await RemoveUserAndImage(user.Id, user.ImageUrl);
                }

                bool isConflict = db.Rents
                .Any(r => r.GalleryId == galleryId &&
                r.CheckinDate <= newStartDate &&
                r.CheckoutDate >= newEndDate);
                if (isConflict)
                {
                    ModelState.AddModelError(string.Empty, "Bu tarihler arasında bu ev için zaten bir rezervasyon var.");
                    await RemoveUserAndImage(user.Id, user.ImageUrl);
                    return View(model);
                }

                int days = (rent.CheckoutDate-rent.CheckinDate).Days;
                if (days == price.Day)
                {
                    rent.Status = true;
                    rent.IsDeleted = false;
                    rent.CreatedDate = DateTime.Now;
                    rent.CreatedBy = Convert.ToInt32(User.Claims.FirstOrDefault(r => r.Type == ClaimTypes.NameIdentifier)?.Value);

                    db.Rents.Add(rent);
                    db.SaveChanges();
                    string fullname = model.FirstName + " " + model.LastName;
                    MailSender.SendReservationMail(fullname, new List<string> { model.Email }, gallery.House.Title, gallery.House.Address, gallery.House.Email, model.CheckinDate, model.CheckoutDate, price.Prices);
                }
                else 
                {
					var models = new ContractViewModels
					{
						CleaningPrice = price.CleaningPrice,
						Cost = price.Cost,
						TotalPrice = price.CleaningPrice + price.Cost,
						Day = price.Day,
					};
					ModelState.AddModelError("CheckoutDate", "Girilen tarih aralığı gün sayısını geçmemeli.");
                    await RemoveUserAndImage(user.Id, user.ImageUrl);

					
					return View(models);
                }
                TempData["SuccessMessage"] = "Verileriniz kaydedilmiştir.";
                return RedirectToAction("House", "Home");
            }
            catch
            {
                var price = await db.Prices
                .Include(h => h.House)
                .FirstOrDefaultAsync(m => m.HouseId == id);

                var models = new ContractViewModels
                {
                    CleaningPrice = price.CleaningPrice,
                    Cost = price.Cost,
                    TotalPrice = price.CleaningPrice + price.Cost,
                    Day = price.Day,
                };
                return View(models);
            }
        }
        private async Task RemoveUserAndImage(int userId, string imageUrl)
        {
            var deleteUser = db.Users.Find(userId);
            if (deleteUser != null)
            {
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    await ImageUploader.DeleteImageAsync(_environment, imageUrl);
                }

                db.Users.Remove(deleteUser);
                db.SaveChanges();
            }
        }
    }
}

