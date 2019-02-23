using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPet.Managers;
using MyPet.Managers.Interfaces;
using MyPet.Models.DTOs;
using MyPet.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PetsController : ControllerBase
    {
        private readonly IPetManager petManager;

        public PetsController(IPetManager petManager)
        {
            this.petManager = petManager;
        }
        //GET api/pets
        [HttpGet]
        public IActionResult GetPetsByOwner()
        {
            //authentication
            var userId = Int32.Parse(User.FindFirst("UserId").Value);
            var pets = petManager.GetPetsByOwner(userId);
            return Ok(pets);
        }

        // POST api/pets
        [HttpPost]
        public IActionResult CreatePet(PetRegisterDto pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //authentication
            var userId = Int32.Parse(User.FindFirst("UserId").Value);
            pet.OwnerId = userId;

            try
            {
                var newPet = petManager.CreatePet(pet);
                return Ok(newPet);
            }
            catch (CustomDbConflictException e)
            {
                return BadRequest(e.Message);
            }

        }

         //PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, PetUpdateDto pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //authentication
            var userId = Int32.Parse(User.FindFirst("UserId").Value);
            try
            {
                var newPet = petManager.UpdatePet(id, userId, pet);
                return Ok(newPet);
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

            try
            {
                petManager.DeletePet(id, userId);
                return Ok();
            }
            catch (CustomDbConflictException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
