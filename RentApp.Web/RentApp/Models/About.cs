using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentApp.Models
{
    public class About : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(64)]
        public string Title { get; set; }

        [Required, StringLength(128)]
        public string Description { get; set; }

        [StringLength(128)]
        public string? ImageUrl { get; set; }
    }
}
