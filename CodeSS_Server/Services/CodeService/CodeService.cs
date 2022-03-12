using AutoMapper;
using CodeSS_Server.CoreEF.Repository;
using CodeSS_Server.Helpers;
using CodeSS_Server.Models;
using CodeSS_Server.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSS_Server.Services.CodeService
{
    public class CodeService : RepositoryBase<Code>, ICodeService
    {
        private readonly IMapper _mapper;
        private readonly ICodeCategoryService _codeCategoryService;
        public CodeService(DataContext context,
            IMapper mapper,
            ICodeCategoryService codeCategoryService) : base(context)
        {
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
                }
                catch (Exception e)
                {
                    code.CodeCategory = null;
                }
            }
            Create(code);
            Save();
            return code;
        }

        public IEnumerable<Code> GetUserCodes(Guid userId)
        {

            var codes = FindByCondition(c => c.User.Id == userId).Include("CodeCategory");
            return codes;
        }

        public void Update(Guid id, CodeRequest model)
        {
            var code = GetById(id);
            _mapper.Map(model, code);
            code.CodeCategory = _codeCategoryService.GetCategory(model.CodeCategoryId);
            Update(code);
            Save();
        }

        public override Code GetById(Guid id)
        {
            var code = FindByCondition(c => c.Id == id).Include("CodeCategory").First();
            if (code == null) throw new KeyNotFoundException("Code not found");
            return code;
        }
    }
}
