using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RentApp.Models
{
    public class House : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(64)]
        public string Title { get; set; }

        [Required, StringLength(128)]
        public string? Description { get; set; }

        [Required]
        public byte AdultCount { get; set; }

        [Required]
        public byte ChildCount { get; set; }

        [Required]
        public byte RoomCount { get; set; }

        [Required]
        public byte BathCount { get; set; }

        [Required]
        public string Floors { get; set; }

        [Required, StringLength(128)]
        [EmailAddress(ErrorMessage = "Lütfen Geçerli Bir E-Mail Adresi Giriniz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        [Required, StringLength(128)]
        public string Address { get; set; }

        [StringLength(128)]
        public string? ImageUrl1 { get; set; }

        public ICollection<Gallery> Images { get; set; }

        public ICollection<Price> Prices { get; set; }

        public ICollection<Rent> Rent { get; set; }
    }
}
