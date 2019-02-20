using System;
using System.Collections.Generic;
using MyPet.Models.DTOs;

namespace MyPet.Managers.Interfaces
{
    public interface IPetManager
    {
        IEnumerable<PetDto> GetPetsByOwner(int ownerId);
        PetDto CreatePet(PetDto pet);
        PetDto UpdatePet(PetDto pet);
        void DeletePet(int petId, int ownerId);
    }
}
