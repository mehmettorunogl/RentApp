using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace RentApp.Models
{
    public class User : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Email { get; set; }

        public string Phone { get; set; }

        public string IdentityNumber { get; set; }
        public string Address { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime BirthDate { get; set; }
        public string? ImageUrl { get; set; }

        public Role Role { get; set; }
        public ICollection<Rent> Rents { get; set; }
    }
}
