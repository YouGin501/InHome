using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace web_site_Domain.Models
{
    public class Like
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public int? PostId { get; set; }
        public int? ProjectId { get; set; }
        public virtual User? User { get; set; }
        [JsonIgnore]
        public virtual Post? Post { get; set; }
        [JsonIgnore]
        public virtual Project? Project { get; set; }
    }
}
