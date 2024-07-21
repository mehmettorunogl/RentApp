using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentApp.Models
{
    public class House : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(64)]
        public string Title { get; set; }

        public string? Description { get; set; }

        public int Capacity { get; set; }

        public int Address { get; set; }

        [Required, StringLength(128)]
        public string? ImageUrl1 { get; set; }

        public ICollection<Gallery> Images { get; set; }

        public ICollection<Price> Prices { get; set; }

        public ICollection<Rent> Rent { get; set; }
    }
}
