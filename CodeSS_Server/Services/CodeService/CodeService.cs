using AutoMapper;
using CodeSS_Server.Helpers;
using CodeSS_Server.Models;
using CodeSS_Server.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSS_Server.Services.CodeService
{
    public class CodeService : ICodeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ICodeCategoryService _codeCategoryService;
        public CodeService(DataContext context,
            IMapper mapper,
            ICodeCategoryService codeCategoryService)
        {
            _context = context;
            _mapper = mapper;
            _codeCategoryService = codeCategoryService;
        }
        public Code Create(User user, CodeRequest model)
        {
            var code = _mapper.Map<Code>(model);
            code.User = user;
            if (model.CodeCategoryId != Guid.Empty)
            {
                try
                {
                    var category = _codeCategoryService.GetCategory(model.CodeCategoryId);
                    code.CodeCategory = category;
                } catch(Exception e)
                {
                    code.CodeCategory = null;
                }
            }
            _context.Codes.Add(code);
            _context.SaveChanges();
            return code;
        }

        public void Delete(Guid id)
        {
            var entity = GetCode(id);
            _context.Codes.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Code> GetUserCodes(Guid userId)
        {
            return _context.Codes.Where(c => c.User.Id == userId);
        }

        public void Update(Guid id, CodeRequest model)
        {
            var code = GetCode(id);
            // validate
            if (model.Name != code.Name && _context.CodeCategories.Any(x => x.Name == model.Name))
                throw new AppException("Code '" + model.Name + "' is already taken");

            // copy model to user and save
            _mapper.Map(model, code);
            _context.Codes.Update(code);
            _context.SaveChanges();
        }

        public Code GetCode(Guid id)
        {
            var code = _context.Codes.Find(id);
            if (code == null) throw new KeyNotFoundException("Code not found");
            return code;
        }
    }
}
