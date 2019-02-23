using System;
using System.Collections.Generic;
using MyPet.Data.Interfaces;
using MyPet.Managers.Interfaces;
using MyPet.Models.DTOs;
using System.Linq;
using MyPet.Utils;
using AutoMapper;
using MyPet.Models;

namespace MyPet.Managers
{
    public class PetManager : IPetManager
    {
        private readonly IPetRepository petRepository;
        private readonly IMapper mapper;

        public PetManager(IPetRepository petRepository, IMapper mapper)
        {
            this.petRepository = petRepository;
            this.mapper = mapper;
        }

        public PetDisplayDto CreatePet(PetRegisterDto pet)
        {
            if(!petRepository.Records.Any(x => x.OwnerId == pet.OwnerId && x.Name == pet.Name))
            {
                throw new CustomDbConflictException("Pet name exsisted.");
            }
            //add
            var newPet = mapper.Map<PetRegisterDto, Pet>(pet);
            newPet = petRepository.Add(newPet);

            var displayPet = mapper.Map<Pet, PetDisplayDto>(newPet);
            return displayPet;
        }

        public void DeletePet(int petId, int ownerId)
        {
            if (!petRepository.Records.Any(x => x.PetId == petId && x.OwnerId == ownerId))
            {
                throw new CustomDbConflictException("Pet not found.");
            }
            var pet = petRepository.Records.Where(x => x.PetId == petId).FirstOrDefault();
            petRepository.Delete(pet);
        }

        public IEnumerable<PetDisplayDto> GetPetsByOwner(int ownerId)
        {
            var pets = petRepository.GetPetsByOwner(ownerId);

            var displayPets = mapper.Map<List<Pet>, List<PetDisplayDto>>(pets);
            return displayPets;
        }

        public PetDisplayDto UpdatePet(int petId, int ownerId, PetUpdateDto pet)
        {
            if(!petRepository.Records.Any(x=>x.PetId == petId && x.OwnerId == ownerId))
            {
                throw new CustomDbConflictException("Pet not found.");
            }
            var oldPet = petRepository.Records.Where(x => x.PetId == petId).FirstOrDefault();
            var updatedPet = petRepository.PartialUpdate(oldPet, pet);
            var displayPet = mapper.Map<Pet, PetDisplayDto>(updatedPet);
            return displayPet;
        }
    }
}
