using System;
using MyPet.Models;
using MyPet.Models.DTOs;

namespace MyPet.Managers.Interfaces
{
    public interface IUserManager
    {
        UserDisplayDto CreateUser(UserRegisterDto user);
        UserDisplayDto GetUserById(int id);
        void DeleteUser(int id);
        UserDisplayDto UpdateUser(int id, UserUpdateDto updateInfo);
    }
}
