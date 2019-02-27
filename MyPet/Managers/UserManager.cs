using System;
using AutoMapper;
using MyPet.Data.Interfaces;
using MyPet.Managers.Interfaces;
using MyPet.Models;
using MyPet.Models.DTOs;
using MyPet.Utils;
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
                throw new CustomDbConflictException("User name exsisted.");
            }
            userRepository.Add(user);

            var displayUser = mapper.Map<User, UserDisplayDto>(user);
            return displayUser;
        }

        public void DeleteUser(int id)
        {
            if (!userRepository.Records.Any(x => x.Id == id))
            {
                throw new CustomDbConflictException("User not exsisted.");
            }
            var user = userRepository.GetById(id);
            userRepository.Delete(user);
        }

        public UserDisplayDto GetUserById(int id)
        {
            if (!userRepository.Records.Any(x => x.Id == id))
            {
                throw new CustomDbConflictException("User not exsisted.");
            }
            var user = userRepository.GetById(id);
            var displayUser = mapper.Map<User, UserDisplayDto>(user);
            return displayUser;
        }

        public UserDisplayDto UpdateUser(UserUpdateDto updateUser)
        {
            if (!userRepository.Records.Any(x => x.Id == updateUser.Id))
            {
                throw new CustomDbConflictException("User not exsisted.");
            }
            if (userRepository.Records.Any(x => x.UserName == updateUser.UserName))
            {
                throw new CustomDbConflictException("User name exsisted.");
            }

            var user = userRepository.GetById(updateUser.Id);
            user = userRepository.PartialUpdate(user, updateUser);
            foreach (var pet in user.Pets)
            {
                pet.Owner = null;
            }
            var displayUser = mapper.Map<User, UserDisplayDto>(user);
            return displayUser;
        }
    }
}
