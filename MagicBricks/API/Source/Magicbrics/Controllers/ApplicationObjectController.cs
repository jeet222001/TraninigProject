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
    public class ApplicationObjectController : ControllerBase
    {
        private IApplicationObjectService ApplicationObjectService { get; set; }
        public ApplicationObjectController(IApplicationObjectService applicationObjectService)
        {
            ApplicationObjectService = applicationObjectService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ApplicationObjectService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(ApplicationObjectService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] ApplicationObject applicationObject)
        {
            return Ok(ApplicationObjectService.Add(applicationObject));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] ApplicationObject applicationObject)
        {
            return Ok(ApplicationObjectService.Update(id, applicationObject));
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            return Ok(ApplicationObjectService.Remove(id));
        }
    }
}
