using System;
using AutoMapper;
using MyPet.Data.Interfaces;
using MyPet.Managers.Interfaces;
using MyPet.Models;
using MyPet.Models.DTOs;

namespace MyPet.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public User CreateUser(UserRegisterDto registerUser)
        {
            //mapper
            var user = mapper.Map<UserRegisterDto, User>(registerUser);
            return user;
            //return userRepository.Add(user);
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
