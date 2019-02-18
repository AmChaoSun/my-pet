using System;
using AutoMapper;
using MyPet.Data.Interfaces;
using MyPet.Managers.Interfaces;
using MyPet.Models;
using MyPet.Models.DTOs;
using System.Linq;

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

        public UserDisplayDto CreateUser(UserRegisterDto registerUser)
        {
            //mapper
            var user = mapper.Map<UserRegisterDto, User>(registerUser);
            if (userRepository.Records.Any(x => x.UserName == user.UserName))
            {
                return null;
            }
            userRepository.Add(user);
            foreach(var pet in user.Pets)
            {
                pet.Owner = null;
            }
            var displayUser = mapper.Map<User, UserDisplayDto>(user);
            return displayUser;
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public UserDisplayDto GetUserById(int id)
        {
            if (!userRepository.Records.Any(x => x.Id == id))
            {
                return null;
            }
            var user = userRepository.GetById(id);
            foreach (var pet in user.Pets)
            {
                pet.Owner = null;
            }
            var displayUser = mapper.Map<User, UserDisplayDto>(user);
            return displayUser;
        }

        public UserDisplayDto UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
