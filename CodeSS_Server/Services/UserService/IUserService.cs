using CodeSS_Server.CoreEF.Repository;
using CodeSS_Server.Models;
using CodeSS_Server.Models.Entities;
using System;

namespace CodeSS_Server.Services
{
    public interface IUserService : IRepositoryBase<User>
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        void Register(RegisterRequest model);
        void Update(Guid id, UpdateUserRequest model);
    }
}
