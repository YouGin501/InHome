using System.ComponentModel.DataAnnotations;
using web_site_Domain.Models;

namespace web_site.Controllers.Models
{
    public class DocumentsRequest
    {
        [Required]
        public Document[]? Documents { get; set; }
    }
}
