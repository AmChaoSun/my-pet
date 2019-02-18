using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyPet.Managers.Interfaces;
using MyPet.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager authManager;
        public AuthController(IAuthManager authManager)
        {
            this.authManager = authManager;
        }
        // POST api/values
        [HttpPost("token")]
        public IActionResult Post(User user)
        {
            return Ok(authManager.Authenticate(user.UserName, user.Password));
        }
    }
}
