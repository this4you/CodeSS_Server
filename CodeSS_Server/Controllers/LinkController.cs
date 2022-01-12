using AutoMapper;
using CodeSS_Server.Models.Entities;
using CodeSS_Server.Models.LinkController;
using CodeSS_Server.Services.LinkConroller;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodeSS_Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : BaseController
    {
        //private IMapper _mapper;

        private ILinkService _linkService;

        public LinkController(ILinkService linkService )
        {
            _linkService = linkService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            
            return Ok(new { message = "" });
        }

        [HttpPost]
        public IActionResult Create( LinkRequest request)
        {
            Link link = _linkService.Create(UserData, request);
            return Ok(new { link });
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, LinkRequest model)
        {
            _linkService.Update(id, model);
            return Ok(new { message = "Link updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _linkService.Delete(id);
            return Ok(new { message = "Link deleted successfully" });
        }
    }
}
