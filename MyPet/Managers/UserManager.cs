using System;
using MyPet.Data.Interfaces;
using MyPet.Managers.Interfaces;
using MyPet.Models;
using MyPet.Models.DTOs;

namespace MyPet.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;
        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User CreateUser(UserRegisterDto registerUser)
        {
            
            throw new NotImplementedException();
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
