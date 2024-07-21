using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentApp.Models
{
    public class Comment : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RentId { get; set; }
        [ForeignKey("RentId")]
        public virtual Rent Rent { get; set; }

        public byte CleanPoint { get; set; }
        public byte GeneralPoint { get; set; }

        public string Message { get; set; }

    }
}
