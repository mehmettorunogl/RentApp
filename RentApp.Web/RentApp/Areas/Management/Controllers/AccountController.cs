using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RentApp.Areas.Management.Models;
using System.Security.Claims;
using RentApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace RentApp.Areas.Management.Controllers
{
	public class AccountController : Controller
    {
        RentDbContext db = new RentDbContext();
        public IActionResult Login()
        {
			ViewBag.Message = "";
			return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var account = db.Accounts.FirstOrDefault(u =>
                u.Email == model.Email &&
                u.Status &&
                u.IsDeleted == false &&
                u.Role != Role.User);


                if (account == null)
                {
					ModelState.AddModelError(string.Empty, "Böyle bir kullanıcı bulunamadı.");
                    return View(model);
                }

                var passwordHasher = new PasswordHasher<Account>();
                var passwordVerificationResult = passwordHasher.VerifyHashedPassword(account, account.Password, model.Password);

                if (passwordVerificationResult == PasswordVerificationResult.Failed)
                {
					ModelState.AddModelError(string.Empty, "Şifre yanlış");
                    return View(model);
                }

                var claims = new List<Claim>
                {
                        new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                        new Claim(ClaimTypes.Name, account.FullName),
                        new Claim(ClaimTypes.Email, account.Email),
                        new Claim(ClaimTypes.MobilePhone, account.Phone),
                        new Claim(ClaimTypes.Role, account.Role.ToString()),
                };

				var claimsIdentity = new ClaimsIdentity(claims,
					CookieAuthenticationDefaults.AuthenticationScheme);

				var authProperties = new AuthenticationProperties
				{
					IssuedUtc = DateTime.UtcNow,
					ExpiresUtc = DateTime.UtcNow.AddHours(6),
				};

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity),
				authProperties);

				return RedirectToAction("Index", "Dashboard");
            }

			ModelState.AddModelError(string.Empty, "Lütfen bilgilerinizi eksiksiz doldurun.");
            return View(model);
        }
		[Authorize(Roles = "SuperAdmin, Developer")]
		public IActionResult Register()
        {
			ViewBag.Message = "";
			return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var account = new Account
                {
                    FullName = model.FullName,
                    IdentityNumber = model.IdentityNumber,
                    Phone = model.Phone,
                    Email = model.Email,
                    Role = model.Role,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 0,
                    Status = true,
                };

                var passwordHasher = new PasswordHasher<Account>();
                account.Password = passwordHasher.HashPassword(account, model.Password);
                db.Add(account);
                db.SaveChanges();
                ViewBag.Message = "Kayıt işlemi başarıyla tamamlandı.";

				var claims = new List<Claim> {
						new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
						new Claim(ClaimTypes.Name, account.FullName),
						new Claim(ClaimTypes.Email, account.Email),
						new Claim("Phone", account.Phone),
						new Claim(ClaimTypes.Role, account.Role.ToString()),
				};

				var claimsIdentity = new ClaimsIdentity(claims,
					CookieAuthenticationDefaults.AuthenticationScheme);

				var authProperties = new AuthenticationProperties
				{
					IssuedUtc = DateTime.UtcNow,
					ExpiresUtc = DateTime.UtcNow.AddHours(6),
				};

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity),
				authProperties);
				return RedirectToAction("Analytics", "Dashboard");
            }
            ViewBag.Message = "Lütfen bilgilerinizi eksiksiz doldurun.";
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}
