using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPet.Managers.Interfaces;
using MyPet.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager userManager;
        public UsersController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var userId = Int32.Parse(User.FindFirst("UserId").Value);

            if(!(userId == id))
            {
                return Forbid();
            }

            var displayUser = userManager.GetUserById(id);
            if (displayUser == null)
            {
                return BadRequest("User not exsisted");
            }
            return Ok(displayUser);
        }

        // POST api/values
        [AllowAnonymous]
        [HttpPost]
        public IActionResult RegisterUser(UserRegisterDto registerUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var displayUser = userManager.CreateUser(registerUser);
            if (displayUser == null)
            {
                return BadRequest("UserName exisited.");
            }
            return Ok(displayUser);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
