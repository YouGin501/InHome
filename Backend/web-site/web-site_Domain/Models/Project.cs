using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web_site_Domain.Enums;

namespace web_site_Domain.Models
{
    public abstract class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Title { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        //only for pre paid advertizement
        [StringLength(50)]
        public string? AdvertisingLabel { get; set; }
        [Required]
        public ProjectType ProjectType { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public int? LocationId { get; set; }
        public virtual Location? Location { get; set; }
        public virtual List<Like>? Likes { get; set; }

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now; 
        public virtual List<ImageUrl>? PhotosUrls { get; set; }

        [Required]
        public RealEstateStatus RealEstateStatus { get; set; }

        [Required]
        public BuildingType BuildingType { get; set; }
    }
}
