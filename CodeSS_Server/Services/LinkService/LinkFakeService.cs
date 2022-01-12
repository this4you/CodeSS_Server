using AutoMapper;
using CodeSS_Server.Helpers;
using CodeSS_Server.Models.Entities;
using CodeSS_Server.Models.LinkController;
using CodeSS_Server.Services.LinkConroller;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSS_Server.Services.LinkService
{
    public class LinkService : ILinkService
    {

        private DataContext _context;
        //private readonly IMapper _mapper;

        public LinkService(DataContext context)
        {
            _context = context;
        }
        public Link Create(User user, LinkRequest request)
        {
            if (_context.Links.Any(x => x.URL == request.URL && x.User.Id == user.Id))
                throw new AppException("This url already added '" + request.URL + " is already taken");

            var link = new Link
            {
                Name = request.Name,
                URL = request.URL,
                User = user
            };


            
            _context.Links.Add(link);
            _context.SaveChanges();

            return link;
        }

        public IEnumerable<Link> GetUserLink(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, LinkRequest model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
