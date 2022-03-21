using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;
using CodeSS_Server.Authorization;
using CodeSS_Server.Helpers;
using CodeSS_Server.Models;
using CodeSS_Server.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using CodeSS_Server.CoreEF.Repository;

namespace CodeSS_Server.Services
{
    public class UserService : RepositoryBase<User>, IUserService
    {
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserService(
            DataContext context,
            IJwtUtils jwtUtils,
            IMapper mapper) : base(context)
        {
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = RepositoryContext.Users.SingleOrDefault(x => x.Login == model.Login);

            if (user == null || !BCryptNet.Verify(model.Password, user.Password))
                throw new AppException("Username or password is incorrect");

            var response = _mapper.Map<AuthenticateResponse>(user);
            response.JWTToken = _jwtUtils.GenerateToken(user);
            return response;
        }

        public void Register(RegisterRequest model)
        {
            if (RepositoryContext.Users.Any(x => x.Login == model.Login))
                throw new AppException("Login '" + model.Login + "' is already taken");

            var user = _mapper.Map<User>(model);

            user.Password = BCryptNet.HashPassword(model.Password);

            RepositoryContext.Users.Add(user);
            RepositoryContext.SaveChanges();
        }

        public void Update(Guid id, UpdateUserRequest model)
        {
            var user = GetById(id);

            if (model.Login != user.Login && RepositoryContext.Users.Any(x => x.Login == model.Login))
                throw new AppException("Username '" + model.Login + "' is already taken");

            if (!string.IsNullOrEmpty(model.Password))
                user.Password = BCryptNet.HashPassword(model.Password);

            _mapper.Map(model, user);
            Update(user);
            Save();
        }
    }
}
