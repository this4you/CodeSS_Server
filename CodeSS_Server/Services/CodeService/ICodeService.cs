using CodeSS_Server.CoreEF.Repository;
using CodeSS_Server.Models;
using CodeSS_Server.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSS_Server.Services
{
    public interface ICodeService : IRepositoryBase<Code>
    {
        IEnumerable<Code> GetUserCodes(Guid userId);
        Code Create(User user, CodeRequest model);
        void Update(Guid id, CodeRequest model);
    }
}
