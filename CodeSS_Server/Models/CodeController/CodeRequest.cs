using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSS_Server.Models
{
    public class CodeRequest
    {
        [Required]
        public String Name { get; set; }

        [Required]
        public string Text { get; set; }

        public Guid CodeCategoryId { get; set; }
    }
}
