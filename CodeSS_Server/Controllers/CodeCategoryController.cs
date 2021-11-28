using AutoMapper;
using CodeSS_Server.Helpers;
using CodeSS_Server.Models;
using CodeSS_Server.Models.Entities;
using CodeSS_Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeSS_Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CodeCategoryController : ControllerBase
    {
        private ICodeCategoryService _codeCategoryService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public CodeCategoryController(
            ICodeCategoryService codeCategorySer,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _codeCategoryService = codeCategorySer;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            User user = (User)HttpContext.Items["User"];
            var categories = _codeCategoryService.GetUserCategories(user.Id);
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult Create(CodeCategoryRequest request)
        {
            User user = (User)HttpContext.Items["User"];
            CodeCategory codeCategory = _codeCategoryService.Create(user, request);
            return Ok(codeCategory);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, CodeCategoryRequest model)
        {
            _codeCategoryService.Update(id, model);
            return Ok(new { message = "Code category updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _codeCategoryService.Delete(id);
            return Ok(new { message = "Code category deleted successfully" });
        }
    }
}
