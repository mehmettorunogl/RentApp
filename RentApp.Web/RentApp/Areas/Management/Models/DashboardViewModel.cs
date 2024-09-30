using RentApp.Helpers;
using RentApp.Models;
using System.ComponentModel.DataAnnotations;

namespace RentApp.Areas.Management.Models
{
    public class DashboardViewModel
    {
        public int UserCount { get; set; }
        public int OwnerCount { get; set; }
        public int ManagerCount { get; set; }
        public int Contracts { get; set; }
		public Account? LastCreatedUser { get; set; }

		public IEnumerable<Account> LastCreatedUsers { get; set; }

		public Role Role { get; set; }
		public decimal MonthlyIncome { get; set; }
        public decimal DailyIncome { get; set; }
    }
}
