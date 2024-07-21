using System.ComponentModel.DataAnnotations.Schema;

namespace RentApp.Models
{
    public class RentHouse : BaseEntity
    {
        public int RentId { get; set; }
        [ForeignKey("ReservationId")]
        public virtual Rent Rent { get; set; }

        public int HouseId { get; set; }
        [ForeignKey("HouseId")]
        public virtual House House { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
