using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_site_Domain.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SubscriberId { get; set; }
        [Required]
        public int ReceiverId { get; set; }

        [ForeignKey("SubscriberId")]
        [InverseProperty("SubscriberSubscriptions")]
        public virtual User? Subscriber { get; set; }

        [ForeignKey("ReceiverId")]
        [InverseProperty("ReceiverSubscriptions")]
        public virtual User? Receiver { get; set; }
    }
}
