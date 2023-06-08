using Magicbrics.Models;
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
    public class ApplicationObjectTypeController : ControllerBase
    {
        private IApplicationObjectTypeService ApplicationObjectTypeService { get; set; }
        public ApplicationObjectTypeController(IApplicationObjectTypeService applicationObjectTypeService)
        {
            ApplicationObjectTypeService = applicationObjectTypeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ApplicationObjectTypeService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(ApplicationObjectTypeService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] ApplicationObjectType applicationObjectType)
        {
            return Ok(ApplicationObjectTypeService.Add(applicationObjectType));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] ApplicationObjectType applicationObjectType)
        {
            return Ok(ApplicationObjectTypeService.Update(id, applicationObjectType));
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            return Ok(ApplicationObjectTypeService.Remove(id));
        }
    }
}
