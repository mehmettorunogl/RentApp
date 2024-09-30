using System.ComponentModel.DataAnnotations;

namespace RentApp.Models
{
    public class Account : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
	}
}
