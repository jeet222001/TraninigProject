using Magicbrics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Magicbrics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private IImageService ImageService { get; set; }
        public ImagesController(IImageService imageService)
        {
            ImageService = imageService;
        }

        [HttpPost]
        public IActionResult PostImages(List<IFormFile> files)
        {
            return Ok(ImageService.AddImages(files));
        }
    }
}
