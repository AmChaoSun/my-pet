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
            if (userRepository.Records.Any(x => x.Email == user.Email))
            {
                throw new CustomDbConflictException("User Email exsisted.");
            }
            userRepository.Add(user);

            var displayUser = mapper.Map<User, UserDisplayDto>(user);
            return displayUser;
        }

        public void DeleteUser(int id)
        {
            var user = userRepository.Records.Find(id);
            if (user == null)
            {
                throw new CustomDbConflictException("User not exsisted.");
            }
            user = userRepository.GetById(id);
            userRepository.Delete(user);
        }

        public UserDisplayDto GetUserById(int id)
        {
            var user = userRepository.Records.Find(id);
            if (user == null)
            {
                throw new CustomDbConflictException("User not exsisted.");
            }
            var displayUser = mapper.Map<User, UserDisplayDto>(user);
            return displayUser;
        }

        public UserDisplayDto UpdateUser(int id, UserUpdateDto updateInfo)
        {
            //verify user exist or not
            var user = userRepository.Records.Find(id);
            if(user == null)
            {
                throw new CustomDbConflictException("User not exsisted.");
            }

            //verify unique properties
            if (userRepository.Records.Any(x => x.UserName == updateInfo.UserName))
            {
                throw new CustomDbConflictException("User name exsisted.");
            }

            if (userRepository.Records.Any(x => x.Email == updateInfo.Email))
            {
                throw new CustomDbConflictException("User Email exsisted.");
            }

            //update
            user = userRepository.PartialUpdate(user, updateInfo);

            //mapper
            var displayUser = mapper.Map<User, UserDisplayDto>(user);
            return displayUser;
        }
    }
}
