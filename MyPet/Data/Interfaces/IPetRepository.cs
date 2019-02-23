using System;
using System.Collections.Generic;
using MyPet.Models;
using MyPet.Models.DTOs;

namespace MyPet.Data.Interfaces
{
    public interface IPetRepository : IGenericRepository<Pet>
    {
        List<Pet> GetPetsByOwner(int ownerId);
        Pet PartialUpdate(Pet pet, PetUpdateDto updatedpet);
    }
}
