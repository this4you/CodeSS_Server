using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSS_Server.Models
{
    public class CodeCategoryRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
