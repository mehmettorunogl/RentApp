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

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public double DiscountRate { get; set; }

        public decimal Cost { get; set; }
    }
}
