using System.ComponentModel.DataAnnotations;

namespace web_site_Domain.Models
{
    public class PostCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }
        public virtual List<Post>? Posts { get; set; }
    }
}
