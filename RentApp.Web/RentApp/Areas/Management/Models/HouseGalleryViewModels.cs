using RentApp.Models;
using System.ComponentModel.DataAnnotations;

namespace RentApp.Areas.Management.Models
{
    public class HouseGalleryViewModels : BaseEntity
    {
        public int HouseId { get; set; }

		[Required(ErrorMessage = "Lütfen Başlık Alanını Doldurun"),
		 StringLength(128, ErrorMessage = "Bu alan en fazla 128 karakter içermelidir.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Lütfen Açıklama Alanını Doldurun"),
		 StringLength(300, ErrorMessage = "Bu alan en fazla 300 karakter içermelidir."),
		 MinLength(40, ErrorMessage = "Bu alan en az 40 karakter içermelidir.")]
		public string? Description { get; set; }

		[Required(ErrorMessage = "Lütfen Yetişkin Sayısı Alanını Doldurun")]
		public byte AdultCount { get; set; }

		[Required(ErrorMessage = "Lütfen Çocuk Sayısı Alanını Doldurun")] 
		public byte ChildCount { get; set; }

		[Required(ErrorMessage = "Lütfen Oda Sayısı Alanını Doldurun")] 
		public byte RoomCount { get; set; }

		[Required(ErrorMessage = "Lütfen Banyo Sayısı Alanını Doldurun")] 
		public byte BathCount { get; set; }

		[Required(ErrorMessage = "Lütfen Kat Sayısı Alanını Doldurun")] 
		public string Floors { get; set; }

		[Required, StringLength(128)]
		[EmailAddress(ErrorMessage = "Lütfen Geçerli Bir E-Mail Adresi Giriniz.")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = "Lütfen Ülke Alanını Doldurun"),
		 StringLength(32, ErrorMessage = "Bu alan en fazla 32 karakter içermelidir.")]
		public string Country { get; set; }

		[Required(ErrorMessage = "Lütfen İl Alanını Doldurun"),
		 StringLength(32, ErrorMessage = "Bu alan en fazla 32 karakter içermelidir.")]
		public string City { get; set; }

		[Required(ErrorMessage = "Lütfen İlçe Alanını Doldurun"),
		 StringLength(32, ErrorMessage = "Bu alan en fazla 32 karakter içermelidir.")]
		public string District { get; set; }

		[DataType(DataType.MultilineText)]
		[Required(ErrorMessage = "Lütfen Email Adresi Alanını Doldurun"), StringLength(128)]
		public string Address { get; set; }

		[Required(ErrorMessage = "Lütfen Resim Alanını Doldurun")]
		public string? ImageUrl { get; set; }

		//Galeri Modeli
		[Required(ErrorMessage = "Lütfen Resim Alanını Doldurun")]
		public string? ImageUrl1 { get; set; }

		[Required(ErrorMessage = "Lütfen Resim Alanını Doldurun")]
		public string? ImageUrl2 { get; set; }

		[Required(ErrorMessage = "Lütfen Resim Alanını Doldurun")]
		public string? ImageUrl3 { get; set; }

		[Required(ErrorMessage = "Lütfen Resim Alanını Doldurun")]
		public string? ImageUrl4 { get; set; }

		[Required(ErrorMessage = "Lütfen Resim Alanını Doldurun")]
		public string? ImageUrl5 { get; set; }

		[Required(ErrorMessage = "Lütfen Resim Alanını Doldurun")]
		public string? ImageUrl6 { get; set; }

		[Required(ErrorMessage = "Lütfen Resim Alanını Doldurun")]
		public string? ImageUrl7 { get; set; }

		[Required(ErrorMessage = "Lütfen Resim Alanını Doldurun")]
		public string? ImageUrl8 { get; set; }

		//Price Modeli
		[Required(ErrorMessage = "Lütfen Gün Alanını Doldurun")]
        public byte Day { get; set; }

		[Required(ErrorMessage = "Lütfen Tutar Alanını Doldurun")]
		public decimal Cost { get; set; }

		[Required(ErrorMessage = "Lütfen Temizlik Ücreti Alanını Doldurun")]
		public decimal CleaningPrice { get; set; }

    }
}
