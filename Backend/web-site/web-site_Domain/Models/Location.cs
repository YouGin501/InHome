using System.ComponentModel.DataAnnotations;

namespace web_site_Domain.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Country { get; set; }
        [Required]
        [StringLength(50)]
        public string? City { get; set; }
        [StringLength(100)]
        public string? Address { get; set; }

        public virtual List<Project>? Projects { get; set; }
        public virtual List<Post>? Posts { get; set; }

        public virtual List<ResidentialComplex>? ResidentialComplexes {get; set;}
    }
}
