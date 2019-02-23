using System;
using System.Collections.Generic;
using MyPet.Models.DTOs;

namespace MyPet.Managers.Interfaces
{
    public interface IPetManager
    {
        IEnumerable<PetDisplayDto> GetPetsByOwner(int ownerId);
        PetDisplayDto CreatePet(PetRegisterDto pet);
        PetDisplayDto UpdatePet(int petId, int OwnerId, PetUpdateDto pet);
        void DeletePet(int petId, int ownerId);
    }
}
