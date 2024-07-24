using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace RentApp.Models
{
    public class User : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, StringLength(128)]
        [EmailAddress(ErrorMessage = "Lütfen Geçerli Bir E-Mail Adresi Giriniz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public int IdentityNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string? PasswordHash { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string? ImageUrl { get; set; }

        public Role Role { get; set; }
        public ICollection<Rent> Rents { get; set; }
    }
}
