using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentApp.Models
{
    public class About : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Başlık Alanını Doldurun"), 
         StringLength(64, ErrorMessage = "Bu alan en fazla 64 karakter içermelidir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen Açıklama Alanını Doldurun"), 
         StringLength(500, ErrorMessage = "Bu alan en fazla 500 karakter içermelidir.")]
        public string Description { get; set; }

        [StringLength(128)]
        public string? ImageUrl { get; set; }
    }
}
