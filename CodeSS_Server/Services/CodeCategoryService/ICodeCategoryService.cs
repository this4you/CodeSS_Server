using CodeSS_Server.Models;
using CodeSS_Server.Models.Entities;
using System;
using System.Collections.Generic;

namespace CodeSS_Server.Services
{
    public interface ICodeCategoryService
    {
        IEnumerable<CodeCategory> GetUserCategories(Guid userId);
        CodeCategory Create(User user, CodeCategoryRequest request);
        void Update(Guid id, CodeCategoryRequest model);
        void Delete(Guid id);
        CodeCategory GetCategory(Guid id);
    }
}
