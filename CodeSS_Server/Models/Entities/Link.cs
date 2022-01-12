using System;
using System.Text.Json.Serialization;

namespace CodeSS_Server.Models.Entities
{
    public class Link
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        [JsonIgnore]
        public User User { get; set; }

    }
}
