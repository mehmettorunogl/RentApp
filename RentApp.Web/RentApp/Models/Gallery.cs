using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentApp.Models
{
    public class Gallery : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int HouseId { get; set; }
        [ForeignKey("HouseId")]
        public virtual House House { get; set; }

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
