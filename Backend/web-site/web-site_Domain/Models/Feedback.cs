using System.ComponentModel.DataAnnotations;

namespace web_site_Domain.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string? Text { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public virtual User? Author { get; set; }

        public User? WrittenForUser { get; set; }

        [Required]
        public int WrittenForUserId { get; set; }
    }
}
