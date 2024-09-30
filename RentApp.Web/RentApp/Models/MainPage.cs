using NuGet.DependencyResolver;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentApp.Models
{
    public class MainPage : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Üst Başlık Alanını Doldurun"), 
         MaxLength(64, ErrorMessage = "Bu alan en fazla 64 karakter içermelidir.")]
        public string Title1 { get; set; }

        [Required(ErrorMessage = "Lütfen Üst Açıklama Alanını Doldurun"),
         MaxLength(400, ErrorMessage = "Bu alan en fazla 400 karakter içermelidir.")]
        public string Description1 { get; set; }

        [Required(ErrorMessage = "Lütfen Alt Başlık Alanını Doldurun"), 
         StringLength(64, ErrorMessage = "Bu alan en fazla 64 karakter içermelidir.")]
        public string Title2 { get; set; }

        [Required(ErrorMessage = "Lütfen Alt Açıklama Alanını Doldurun"), 
         MaxLength(500, ErrorMessage = "Bu alan en fazla 500 karakter içermelidir.")]
        public string Description2 { get; set; }

        [StringLength(128)]
        public string? ImageUrl1 { get; set; }

        [StringLength(128)]
        public string? ImageUrl2 { get; set; }

        [StringLength(128)]
        public string? ImageUrl3 { get; set; }

        [StringLength(128)]
        public string? ImageUrl4 { get; set; }

		[StringLength(128)]
		public string? FooterAddress { get; set; }

		[StringLength(13)]
		public string? FooterPhone { get; set; }

		[StringLength(100)]
		public string? FooterEmail { get; set; }

		[StringLength(128)]
		public string? FacebookUrl { get; set; }

		[StringLength(128)]
		public string? TwitterUrl { get; set; }

		[StringLength(128)]
		public string? LinkedInUrl { get; set; }

		[StringLength(128)]
		public string? YoutubeUrl { get; set; }

        public ICollection<House> Houses { get; set; }
	}
}
