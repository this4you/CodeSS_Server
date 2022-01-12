using System.ComponentModel.DataAnnotations;

namespace CodeSS_Server.Models.LinkController
{
    public class LinkRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string URL { get; set; }
    }
}
