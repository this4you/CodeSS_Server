using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeSS_Server.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
