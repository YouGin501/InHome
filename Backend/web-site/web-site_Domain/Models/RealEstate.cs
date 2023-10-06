using System.ComponentModel.DataAnnotations;

namespace web_site_Domain.Models
{
    public class RealEstate : Project
    {
        [Required]
        public float LivingSpace { get; set; }
        public int? ResidentialComplexId { get; set; }
        public virtual ResidentialComplex? ResidentialComplex { get; set; }

        [Required]
        public int NumberOfRooms { get; set; }

        public string? ResidentialComplexAppartmentType { get; set; }
    }
}
