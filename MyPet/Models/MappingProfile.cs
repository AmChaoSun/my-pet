using System;
using AutoMapper;
using MyPet.Models.DTOs;
using MyPet.Utils;
using System.Linq;

namespace MyPet.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterDto, User>()
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => HashHelper.GetHashedData(src.Password)));
            CreateMap<User, UserDisplayDto>();
            CreateMap<PetRegisterDto, Pet>();
            CreateMap<Pet, PetDisplayDto>();
        }
    }
}
