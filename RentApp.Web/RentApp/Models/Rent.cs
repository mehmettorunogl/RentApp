using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentApp.Models
{
    public class Rent : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid Code { get; set; }

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal CleaningPrice { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public DateTime CheckinDate { get; set; }

        [Required]
        public DateTime CheckoutDate { get; set; }

        [Required]
        public decimal PrePaymentPrice { get; set; }

        public ICollection<RentHouse> RentHouses { get; set; }
    }
}
