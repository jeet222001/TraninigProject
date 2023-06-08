using Magicbrics.Models;
using Magicbrics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace Magicbrics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private IPropertyService PropertyService { get; set; }
        public PropertiesController(IPropertyService propertyService)
        {
            PropertyService = propertyService;
        }

        [HttpGet]
        public IActionResult GetProperties()
        {
            return Ok(PropertyService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetProperty(int id)
        {
            return Ok(PropertyService.GetById(id));
        }
        [HttpPost]
        public IActionResult AddProperty(Property property)
        {
          return Ok(PropertyService.AddProperty(property));
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProperty(int id,Property property)
        {
            return Ok(PropertyService.UpdateProperty(id, property));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProperty(int id)
        {
            return Ok(PropertyService.DeleteProperty(id));
        }
    }
}
