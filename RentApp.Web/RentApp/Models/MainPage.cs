using System.ComponentModel.DataAnnotations;

namespace RentApp.Models
{
    public class MainPage : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(64)]
        public string Title1 { get; set; }

        [Required]
        public string Description1 { get; set; }

        [Required, StringLength(64)]
        public string Title2 { get; set; }

        [Required]
        public string Description2 { get; set; }

        [StringLength(128)]
        public string? ImageUrl1 { get; set; }

        [StringLength(128)]
        public string? ImageUrl2 { get; set; }

        [StringLength(128)]
        public string? ImageUrl3 { get; set; }

        [StringLength(128)]
        public string? ImageUrl4 { get; set; }

    }
}
