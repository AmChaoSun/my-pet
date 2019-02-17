using System;
using MyPet.Models;
using MyPet.Models.DTOs;

namespace MyPet.Managers.Interfaces
{
    public interface IUserManager
    {
        User CreateUser(UserRegisterDto user);
        User GetUser(int id);
        void DeleteUser(int id);
        User UpdateUser(User user);
    }
}
