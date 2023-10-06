using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace web_site_Domain.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string? Text { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public virtual User? Author { get; set; }

        public int PostId { get; set; }

        [JsonIgnore]
        public virtual Post? Post { get; set; }
    }
}
