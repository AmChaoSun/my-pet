using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyPet.Data.Interfaces;
using MyPet.Models;
using MyPet.Models.DTOs;

namespace MyPet.Data
{
    public class PetRepository : GenericRepository<Pet>, IPetRepository
    {
        public PetRepository(MyPetContext context) : base(context)
        {
        }

        public override void Delete(Pet record)
        {
            base.Delete(record);
        }

        public List<Pet> GetPetsByOwner(int ownerId)
        {
            return Records.Where(x => x.OwnerId == ownerId).ToList();
        }

        public Pet PartialUpdate(Pet pet, PetUpdateDto updatedpet)
        {
            //update
            var entry = context.Entry(pet);
            entry.CurrentValues.SetValues(updatedpet);
            entry.State = EntityState.Modified;

            return pet;
        }

    }
}
