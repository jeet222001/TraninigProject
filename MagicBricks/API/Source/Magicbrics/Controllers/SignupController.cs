using Magicbrics.Models;
using Magicbrics.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magicbrics.Controllers
{
    [Route("bricks/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class SignupController : ControllerBase
    {
        public ISignupService SignupService { get; set; }
        public SignupController(ISignupService signupService)
        {
            SignupService = signupService;
        }

        [HttpGet("users")]
        public  IActionResult GetUsers()
       {
            return Ok(SignupService.GetAll());
        }
        [HttpGet("users/{id}")]
        public  IActionResult GetUser(int id)
        {
            return Ok(SignupService.GetById(id));
        }
     
        [HttpPost("users")]
        public IActionResult Post(User user)
        {
            return Ok(SignupService.AddUserAsync(user));
        }

        [HttpPost("verifyOtp")]
        public IActionResult Otpverify(OtpVerify user)
        {
            return Ok(SignupService.OtpVerify(user));
        }
    }
}
