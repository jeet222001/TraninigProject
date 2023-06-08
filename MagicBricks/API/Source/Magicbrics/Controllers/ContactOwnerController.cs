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
    public class ContactOwnerController : ControllerBase
    {
        private IContactOwnerService ContactOwnerService { get; set; }
        public ContactOwnerController(IContactOwnerService contactOwnerService)
        {
            ContactOwnerService = contactOwnerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ContactOwnerService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            return Ok(ContactOwnerService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] ContactOwner contactOwner)
        {
            return Ok(ContactOwnerService.Add(contactOwner));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] ContactOwner contactOwner)
        {
            return Ok(ContactOwnerService.Update(id, contactOwner));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(ContactOwnerService.Remove(id));
        }
    }
}
