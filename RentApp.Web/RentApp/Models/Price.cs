using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentApp.Models
{
    public class Price : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int HouseId { get; set; }
        [ForeignKey("HouseId")]
        public virtual House House { get; set; }

		[Required]
		public byte Day { get; set; }

		[Required]
		public decimal Prices { get; set; }

		[Required]
		public decimal CleaningPrice { get; set; }

		public double? DiscountRate { get; set; }

        [Required]
        public decimal Cost { get; set; }
    }
}
