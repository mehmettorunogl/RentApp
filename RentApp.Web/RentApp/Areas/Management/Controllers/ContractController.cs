using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentApp.Models;
using System.Security.Claims;

namespace RentApp.Areas.Management.Controllers
{
	[Authorize]
	public class ContractController : Controller
    {
		RentDbContext db = new RentDbContext();

		// GET: ContractController
		public ActionResult Index()
        {
			var rent = db.Rents.Include(c => c.User).Include(c => c.Gallery).ThenInclude(c => c.House).Where(c=>c.Status && c.IsDeleted==false).ToList();
			return View(rent);
		}

        // GET: ContractController/Details/5
        public ActionResult Details(int id)
        {
			var rent = db.Rents.Include(c => c.Gallery).ThenInclude(c => c.House).Include(c => c.User).FirstOrDefault(m => m.Id == id);

			if (rent == null)
			{
				return RedirectToAction("Index");
			}
			return View(rent);
		}

		[Authorize(Roles = "SuperAdmin, Developer")]
		// GET: ContractController/Delete/5
		public ActionResult Delete(int id)
        {
			var rent = db.Rents.Include(c => c.Gallery).ThenInclude(c => c.House).Include(c => c.User).FirstOrDefault(m => m.Id == id);

			if (rent == null)
			{
				return RedirectToAction(nameof(Index));
			}
			return View(rent);
        }

		// POST: ContractController/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			try
			{
				var rent = db.Rents.Include(c => c.Gallery).ThenInclude(c => c.House).Include(c => c.User).FirstOrDefault(m => m.Id == id);

				if (rent == null)
				{
					return RedirectToAction(nameof(Index));
				}
				rent.IsDeleted = true;
				rent.User.IsDeleted = true;
				rent.DeletedDate = DateTime.Now;
				rent.UpdatedBy = Convert.ToInt32(User.Claims.FirstOrDefault(r => r.Type == ClaimTypes.NameIdentifier)?.Value);
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
