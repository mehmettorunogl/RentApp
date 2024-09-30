using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentApp.Models
{
    public class Contact : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Başlık Alanını Doldurun"), 
         StringLength(64, ErrorMessage = "Bu alan en fazla 64 karakter içermelidir.")]

        // title sil
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen İsim Alanını Doldurun"), 
         StringLength(64, ErrorMessage = "Bu alan en fazla 64 karakter içermelidir.")]
        public string Name { get; set; }

        [Required, 
         StringLength(128, ErrorMessage = "Bu alan en fazla 128 karakter içermelidir.")]
        [EmailAddress(ErrorMessage = "Lütfen Geçerli Bir E-Mail Adresi Giriniz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Mesaj Alanını Doldurun"), 
         StringLength(128, ErrorMessage = "Bu alan en fazla 128 karakter içermelidir.")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Lütfen Üst Açıklama Alanını Doldurun"), 
          StringLength(13, ErrorMessage = "Bu alan en fazla 13 karakter içermelidir.")]
        public string PhoneNumber { get; set; }

        [Required]
        public string? Map { get; set; }

        
    }
}
