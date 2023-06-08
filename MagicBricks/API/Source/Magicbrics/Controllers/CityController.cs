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
    public class CityController : ControllerBase
    {
        private ICityService Cityservice { get; set; }
        public CityController(ICityService cityService)
        {
            Cityservice = cityService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Cityservice.GetAll());
        }
    }
}
