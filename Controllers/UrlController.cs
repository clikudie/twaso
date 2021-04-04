using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Twaso.Domain.Models;
using Twaso.Domain.Services;
using Twaso.Resources;

namespace Twaso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;
        private readonly IMapper _mapper;

        public UrlController(IUrlService urlService, IMapper mapper)
        {
            _urlService = urlService;
            _mapper = mapper;
        }

        [HttpGet("{hash}")]
        public async Task<IActionResult> GetAsync(string hash)
        {
            var url = await _urlService.GetUrl(hash);
            return Redirect(url.OriginalUrl);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] UrlResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var url = _mapper.Map<UrlResource, Url>(resource);
            var results = await _urlService.AddAsync(url);

            if (!results.Success)
            {
                return BadRequest(results.Message);
            }

            return Ok(url);
        }
    }
}
