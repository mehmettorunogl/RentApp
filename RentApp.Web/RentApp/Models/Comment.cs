using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentApp.Models
{
    public class Comment : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int RentId { get; set; }
        [ForeignKey("RentId")]
        public virtual Rent Rent { get; set; }

        public byte CleanPoint { get; set; }
        public byte GeneralPoint { get; set; }

        [Required(ErrorMessage = "Lütfen Mesaj Alanını Doldurun"), 
         StringLength(64, ErrorMessage = "Bu alan en fazla 64 karakter içermelidir.")]
        public string Message { get; set; }

    }
}
