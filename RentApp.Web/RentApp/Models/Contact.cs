using System.ComponentModel.DataAnnotations;

namespace RentApp.Models
{
    public class Contact : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(64)]
        public string Title { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, StringLength(128)]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        [StringLength(128)]
        public string? ImageUrl { get; set; }

        public string? Map { get; set; }

        [Required]
        public string FooterAddress { get; set; }

        [Required, StringLength(128)]
        public string FooterPhone { get; set; }

        [Required]
        public string FooterEmail { get; set; }

        [StringLength(128)]
        public string? FacebookUrl { get; set; }

        [StringLength(128)]
        public string? TwitterUrl { get; set; }

        [StringLength(128)]
        public string? LinkedInUrl { get; set; }

        [StringLength(128)]
        public string? YoutubeUrl { get; set; }
    }
}
