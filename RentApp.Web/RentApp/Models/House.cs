using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RentApp.Models
{
    public class House : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int MainPageId { get; set; }
        [ForeignKey("MainPageId")]
        public virtual MainPage MainPage { get; set; }

        [Required(ErrorMessage = "Lütfen Başlık Alanını Doldurun"), 
         StringLength(128, ErrorMessage = "Bu alan en fazla 128 karakter içermelidir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen Açıklama Alanını Doldurun"), 
         StringLength(300, ErrorMessage = "Bu alan en fazla 300 karakter içermelidir."),
         MinLength(40, ErrorMessage ="Bu alan en az 40 karakter içermelidir.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Lütfen Yetişkin Sayısı Alanını Doldurun")]
        public byte AdultCount { get; set; }

		[Required(ErrorMessage = "Lütfen Çocuk Sayısı Alanını Doldurun")] public byte ChildCount { get; set; }

		[Required(ErrorMessage = "Lütfen Oda Sayısı Alanını Doldurun")] public byte RoomCount { get; set; }

		[Required(ErrorMessage = "Lütfen Banyo Sayısı Alanını Doldurun")] public byte BathCount { get; set; }

		[Required(ErrorMessage = "Lütfen Kat Sayısı Alanını Doldurun")] public string Floors { get; set; }

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
        [Required, StringLength(128)]
        public string Address { get; set; }

        [StringLength(128)]
        public string? ImageUrl { get; set; }

		public ICollection<Gallery> Gallery { get; set; }

		public ICollection<Price> Price { get; set; }

        public ICollection<Rent> Rent { get; set; }
    }
}
