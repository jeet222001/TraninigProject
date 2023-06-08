using Magicbrics.Authentication;
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
    public class LoginController : ControllerBase
    {
        private readonly IJWTAuthenticationManager JWTAuthenticationManager;
        public ILoginService LoginService { get; set; }
        public LoginController(ILoginService loginService, IJWTAuthenticationManager jWTAuthenticationManager)
        {
            LoginService = loginService;
            JWTAuthenticationManager = jWTAuthenticationManager;
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            return Ok(LoginService.LoginUser(model));
        }
    }
}
