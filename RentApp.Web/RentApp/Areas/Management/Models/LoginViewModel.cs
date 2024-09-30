using System.ComponentModel.DataAnnotations;

namespace RentApp.Areas.Management.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Mail alanı boş olamaz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş olamaz")]
        public string Password { get; set; }
    }
}
