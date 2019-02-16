using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPet.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        // GET: api/values
        [HttpGet]
        public ActionResult<User> GetAllUsers()
        {
            using(MyPetContext context = new MyPetContext())
            {
                var users = context.Users.ToList();
                return Ok(users);
            }

        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            using (MyPetContext context = new MyPetContext())
            {
                var user = context.Users
                    .Include(x => x.Pets)
                    .FirstOrDefault(x => x.Id == id);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
        }

    }
}
