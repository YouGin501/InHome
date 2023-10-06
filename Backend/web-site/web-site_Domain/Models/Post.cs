using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_site_Domain.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Title { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
        public List<Hashtag>? Hashtags { get; set; }

        public int? LocationId { get; set; }
        public virtual Location? Location { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public virtual List<Comment>? Comments { get; set; }

        public virtual List<ImageUrl>? Photos { get; set; }

        [InverseProperty("Post")]
        public virtual List<Like>? PostLikes { get; set; }
        [Required]
        [DefaultValue("getutcdate()")]
        public DateTime CreationDate { get; set; }
    }
}
