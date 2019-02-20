using System;
using System.Collections.Generic;
using MyPet.Data.Interfaces;
using MyPet.Managers.Interfaces;
using MyPet.Models.DTOs;

namespace MyPet.Managers
{
    public class PetManager : IPetManager
    {
        private readonly IPetRepository petRepository;
        public PetManager(IPetRepository petRepository)
        {
            this.petRepository = petRepository;
        }

        public PetDto CreatePet(PetDto pet)
        {
            throw new NotImplementedException();
        }

        public void DeletePet(int petId, int ownerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PetDto> GetPetsByOwner(int ownerId)
        {
            throw new NotImplementedException();
        }

        public PetDto UpdatePet(PetDto pet)
        {
            throw new NotImplementedException();
        }
    }
}
