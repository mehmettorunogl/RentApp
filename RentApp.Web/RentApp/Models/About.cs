using System.ComponentModel.DataAnnotations;

namespace RentApp.Models
{
    public class About : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(64)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [StringLength(128)]
        public string? ImageUrl { get; set; }
    }
}
