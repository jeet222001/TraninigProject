using Magicbrics.Services;
using Microsoft.AspNetCore.Mvc;


namespace Magicbrics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryService CountryService { get; set; }
        public CountryController(ICountryService countryService)
        {
            CountryService = countryService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(CountryService.GetAll());
        }


    }
}
