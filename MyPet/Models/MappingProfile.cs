using System;
using AutoMapper;
using MyPet.Models.DTOs;

namespace MyPet.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterDto, User>()
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
