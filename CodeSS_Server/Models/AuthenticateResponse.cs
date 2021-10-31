using CodeSS_Server.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSS_Server.Models
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Login = user.Login;
            Token = token;
        }
    }
}
