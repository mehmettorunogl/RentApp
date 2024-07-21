using System.ComponentModel.DataAnnotations;

namespace RentApp.Models
{
    public class Gallery : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public int? HouseId { get; set; }

        [Required, StringLength(128)]
        public string? ImageUrl1 { get; set; }

        [Required, StringLength(128)]
        public string? ImageUrl2 { get; set; }

        [Required, StringLength(128)]
        public string? ImageUrl3 { get; set; }

        [Required, StringLength(128)]
        public string? ImageUrl4 { get; set; }

        [Required, StringLength(128)]
        public string? ImageUrl5 { get; set; }

        [Required, StringLength(128)]
        public string? ImageUrl6 { get; set; }

        [Required, StringLength(128)]
        public string? ImageUrl7 { get; set; }

        [Required, StringLength(128)]
        public string? ImageUrl8 { get; set; }
    }
}
