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

        [Required(ErrorMessage = "Lütfen Adınız Alanını Doldurun"),
         StringLength(64, ErrorMessage = "Bu alan en fazla 64 karakter içermelidir"),
         MinLength(3, ErrorMessage = "Bu alan en az 3 karakter içermelidir")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınız Alanını Doldurun"),
         StringLength(64, ErrorMessage = "Bu alan en fazla 64 karakter içermelidir"),
         MinLength(3, ErrorMessage = "Bu alan en az 3 karakter içermelidir")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Lütfen Email Alanını Doldurun"), 
         StringLength(128)]
        [EmailAddress(ErrorMessage = "Lütfen Geçerli Bir E-Mail Adresi Giriniz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Telefon Alanını Doldurun"),
         StringLength(13, ErrorMessage = "Bu alan 13 karakter içermelidir")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Lütfen Kimlik Numarası Alanını Doldurun"),
         StringLength(11, ErrorMessage = "Bu alan 11 karakter içermelidir")]
        public string IdentityNumber { get; set; }

        [Required(ErrorMessage = "Lütfen Adres Alanını Doldurun"), 
         StringLength(64, ErrorMessage = "Bu alan 64 karakter içermelidir")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Lütfen Doğum Günü Alanını Doldurun")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Lütfen Resim Alanını Doldurun")]
        public string? ImageUrl { get; set; }

        public Role Role { get; set; }

        public ICollection<Rent> Rents { get; set; }
    }
}
