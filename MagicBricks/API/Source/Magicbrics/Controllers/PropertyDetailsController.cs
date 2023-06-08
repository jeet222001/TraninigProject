using Magicbrics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magicbrics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyDetailsController : ControllerBase
    {
        private IPropertyDetailsService PropertyDetailsService { get; set; }
        public PropertyDetailsController(IPropertyDetailsService propertyDetailsService)
        {
            PropertyDetailsService = propertyDetailsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(PropertyDetailsService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(PropertyDetailsService.GetById(id));
        }
    }
}
