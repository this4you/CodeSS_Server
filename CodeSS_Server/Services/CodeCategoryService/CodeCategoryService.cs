using AutoMapper;
using CodeSS_Server.Helpers;
using CodeSS_Server.Models;
using CodeSS_Server.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSS_Server.Services.CodeCategoryService
{
    public class CodeCategoryService : ICodeCategoryService
    {

        private DataContext _context;
        private readonly IMapper _mapper;
        public CodeCategoryService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public CodeCategory Create(User user, CodeCategoryRequest model)
        {
            if (_context.CodeCategories.Any(x => x.Name == model.Name && x.User.Id == user.Id))
                throw new AppException("Category already added '" + model.Name + "' is already taken");

            var codeCategory = _mapper.Map<CodeCategory>(model);
            codeCategory.User = user;
            _context.CodeCategories.Add(codeCategory);
            _context.SaveChanges();

            return codeCategory;
        }

        public void Delete(Guid id)
        {
            var entity = GetCategory(id);
            _context.CodeCategories.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<CodeCategory> GetUserCategories(Guid userId)
        {
            return _context.CodeCategories.Where(c => c.User.Id == userId);
        }

        public void Update(Guid id, CodeCategoryRequest model)
        {
            var category = GetCategory(id);
            // validate
            if (model.Name != category.Name && _context.CodeCategories.Any(x => x.Name == model.Name))
                throw new AppException("Categories '" + model.Name + "' is already taken");

            // copy model to user and save
            _mapper.Map(model, category);
            _context.CodeCategories.Update(category);
            _context.SaveChanges();
        }

        private CodeCategory GetCategory(Guid id)
        {
            var category = _context.CodeCategories.Find(id);
            if (category == null) throw new KeyNotFoundException("Category not found");
            return category;
        }
    }
}
