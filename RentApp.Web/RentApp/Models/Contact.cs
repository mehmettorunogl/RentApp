using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentApp.Models
{
    public class Contact : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(64)]
        public string Title { get; set; }

        [Required, StringLength(64)]
        public string Name { get; set; }

        [Required, StringLength(128)]
        [EmailAddress(ErrorMessage = "Lütfen Geçerli Bir E-Mail Adresi Giriniz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, StringLength(128)]
        public string Message { get; set; }

        [StringLength(128)]
        public string? ImageUrl { get; set; }

        [Required]
        public string? Map { get; set; }

        [Required]
        public string FooterAddress { get; set; }

        [Required, StringLength(128)]
        public string FooterPhone { get; set; }

        [Required, StringLength(128)]
        public string FooterEmail { get; set; }

        [StringLength(128)]
        public string? FacebookUrl { get; set; }

        [StringLength(128)]
        public string? TwitterUrl { get; set; }

        [StringLength(128)]
        public string? LinkedInUrl { get; set; }

        [StringLength(128)]
        public string? YoutubeUrl { get; set; }
    }
}
