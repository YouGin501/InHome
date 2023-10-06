using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace web_site_Domain.Models
{
    public class ImageUrl
    {
        [Key]
        public int Id { get; set; }
        public string? Url { get; set; }
        public string? FileName { get; set; }

        public int? PostId { get; set; }
        public virtual Post? Post { get; set; }

        public int? ProjectId { get; set; }
        public virtual Project? Project { get; set; }

        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        public int? ResidentialComplexId { get; set; }
        public ResidentialComplex? ResidentialComplex { get; set; }
    }
}
