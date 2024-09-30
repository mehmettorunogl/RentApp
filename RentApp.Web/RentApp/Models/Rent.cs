using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace RentApp.Models
{
    public class Rent : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int GalleryId { get; set; }
        [ForeignKey("GalleryId")]
        public virtual Gallery Gallery { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "Lütfen Giriş Tarihi Alanını Doldurun")]
        public DateTime CheckinDate { get; set; }

        [Required(ErrorMessage = "Lütfen Çıkış Tarihi Alanını Doldurun")]
        public DateTime CheckoutDate { get; set; }

        [Required]
        public decimal PrePaymentPrice { get; set; }

    }
}
