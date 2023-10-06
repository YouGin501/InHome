using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using web_site_Domain.Enums;

namespace web_site_Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        public string? Surname { get; set; }

        [Required]
        [StringLength(50)]
        public string? Email { get; set; }

        [Required]
        [StringLength(50)]
        public string? Password { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }
        public ImageUrl? Photo { get; set; }

        [Required]
        public UserType UserType { get; set; }

        [Required]
        public Role Role { get; set; }
        public virtual List<Comment>? Comments { get; set; }

        [InverseProperty("Subscriber")]
        public virtual List<Subscription>? SubscriberSubscriptions { get; set; }

        [InverseProperty("Receiver")]
        public virtual List<Subscription>? ReceiverSubscriptions { get; set; }

        [InverseProperty("User")]
        public virtual List<Like>? UserLikes { get; set; }

        [StringLength(1000)]
        public string? Information { get; set; }

        [Column(TypeName = "float")]
        public float Rating { get; set; }
        public List<Document>? Documents { get; set; }

        public List<Feedback>? Feedbacks { get; set; }

        [NotMapped]
        public virtual List<Post>? Posts { get; set; }
        public virtual List<Project>? Projects { get; set; }

        public virtual List<ResidentialComplex>? ResidentialComplexes { get; set; }
    }
}
