using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_site_Domain.Models
{
    public class ResidentialComplex
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<ImageUrl>? PhotoUrls { get; set; }
        public int? LocationId { get; set; }
        public virtual Location? Location { get; set; }
        public List<RealEstate>? Apartments { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
