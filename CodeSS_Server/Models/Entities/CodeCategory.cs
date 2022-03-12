using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeSS_Server.Models.Entities
{
    public class CodeCategory : BaseEntity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
