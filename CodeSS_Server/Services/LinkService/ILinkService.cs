using CodeSS_Server.Models.Entities;
using CodeSS_Server.Models.LinkController;
using System;
using System.Collections.Generic;

namespace CodeSS_Server.Services.LinkConroller
{
    public interface ILinkService
    {
        IEnumerable<Link> GetUserLink(Guid userId);
        Link Create(User user, LinkRequest request);
        void Update(Guid id, LinkRequest model);
        void Delete(Guid id);
    }
}
