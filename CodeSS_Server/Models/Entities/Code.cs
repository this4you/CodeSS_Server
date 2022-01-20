using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CodeSS_Server.Models.Entities
{
    public class Code
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string Text { get; set; }
        public CodeCategory CodeCategory { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
