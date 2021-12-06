using CodeSS_Server.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSS_Server.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        public User UserData => (User)HttpContext.Items["User"];
    }
}
