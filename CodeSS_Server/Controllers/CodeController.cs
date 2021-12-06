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
    public class CodeController : BaseController
    {
        private readonly ICodeService _codeService;
        private readonly IMapper _mapper;

        public CodeController(
            ICodeService codeService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _codeService = codeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var codes = _codeService.GetUserCodes(UserData.Id);
            return Ok(codes);
        }

        [HttpPost]
        public IActionResult Create(CodeRequest request)
        {
            Code code = _codeService.Create(UserData, request);
            return Ok(code);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, CodeRequest model)
        {
            _codeService.Update(id, model);
            return Ok(new { message = "Code updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _codeService.Delete(id);
            return Ok(new { message = "Code deleted successfully" });
        }
    }
}
