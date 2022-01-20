using CodeSS_Server.Models;
using CodeSS_Server.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSS_Server.Services
{
    public interface ICodeService
    {
        IEnumerable<Code> GetUserCodes(Guid userId);
        Code GetById(Guid id);
        Code Create(User user, CodeRequest model);
        void Update(Guid id, CodeRequest model);
        void Delete(Guid id);
    }
}
