using RentApp.Helpers;
using RentApp.Models;
using System.ComponentModel.DataAnnotations;

namespace RentApp.Areas.Management.Models
{
    public class RegisterViewModel : BaseEntity
    {
		[Required(ErrorMessage = "Rol seçimi gerekli.")]
		public Role Role { get; set; }

		[Required(ErrorMessage = "İsim Soyisim gerekli."),
         StringLength(64, ErrorMessage ="Maksimum 64 Karakter İçermelidir")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Lütfen Adınız Alanını Doldurun"),
         StringLength(11, ErrorMessage = "Bu alan en fazla 11 karakter içermelidir"),
         MinLength(3, ErrorMessage = "Bu alan en az 3 karakter içermelidir")]
        public string IdentityNumber { get; set; }

        [Required(ErrorMessage = "Lütfen Adınız Alanını Doldurun"),
         StringLength(11, ErrorMessage = "Bu alan en fazla 11 karakter içermelidir")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Lütfen Email Alanını Doldurun")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Adınız Alanını Doldurun"),
         StringLength(20, ErrorMessage = "Bu alan en fazla 20 karakter içermelidir"),
         MinLength(8, ErrorMessage = "Bu alan en az 8 karakter içermelidir")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Adınız Alanını Doldurun"),
         StringLength(20, ErrorMessage = "Bu alan en fazla 20 karakter içermelidir"),
         MinLength(8, ErrorMessage = "Bu alan en az 8 karakter içermelidir")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor. Tekrar Deneyinizç")]
        public string ConfirmPassword { get; set; }

	}
}
