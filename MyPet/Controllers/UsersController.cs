using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPet.Managers.Interfaces;
using MyPet.Models.DTOs;
using MyPet.Utils;

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
            //authentication
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
            //model validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var displayUser = userManager.CreateUser(registerUser);
                return Ok(displayUser);
            }
            catch (CustomDbConflictException e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody]UserUpdateDto user)
        {
            //model validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //authentication
            var userId = Int32.Parse(User.FindFirst("UserId").Value);
            if (!(userId == id))
            {
                return Forbid();
            }

            user.Id = id;
            try
            {
                var displayUser = userManager.UpdateUser(user);
                return Ok(displayUser);
            }
            catch (CustomDbConflictException e)
            {
                return BadRequest(e.Message);
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //authentication
            var userId = Int32.Parse(User.FindFirst("UserId").Value);
            if (!(userId == id))
            {
                return Forbid();
            }
            userManager.DeleteUser(id);
            return Ok();
        }
    }
}
