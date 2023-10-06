using System.ComponentModel.DataAnnotations;

namespace web_site_Domain.Models
{
    public class Rent : Project
    {
        public int MinimalRentPeriod { get; set; }

        [Required]
        public float LivingSpace { get; set; }

        [Required]
        public int NumberOfRooms { get; set; }
    }
}
