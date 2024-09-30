using System.ComponentModel.DataAnnotations;

namespace RentApp.Models.ContractViewModels
{
    public class ContractViewModels : BaseEntity
    {

        public int HouseId { get; set; }
        public int RentId { get; set; }
        public int GalleryId { get; set; }
        public int UserId { get; set; }
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
        public byte Day { get; set; }
        public decimal Cost { get; set; }
        public decimal CleaningPrice { get; set; }
		public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "Lütfen Giriş Tarihi Alanını Doldurun")]
        public DateTime CheckinDate { get; set; }

        [Required(ErrorMessage = "Lütfen Çıkış Tarihi Alanını Doldurun")]
        public DateTime CheckoutDate { get; set; }
        public decimal PrePaymentPrice { get; set; }
    }
}
