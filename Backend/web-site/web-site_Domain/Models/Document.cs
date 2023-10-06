using System.ComponentModel.DataAnnotations;

namespace web_site_Domain.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        public string? FileName { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
