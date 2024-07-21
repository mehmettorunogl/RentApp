using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentApp.Models
{
    public class Rent : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid Code { get; set; }

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public decimal Price { get; set; }

        public decimal CleaningPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }

        public decimal PrePaymentPrice { get; set; }

        public ICollection<RentHouse> RentHouses { get; set; }
    }
}
