using System;
using MyPet.Models;
using MyPet.Models.DTOs;

namespace MyPet.Data.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User PartialUpdate(User user, UserUpdateDto updateUser);
    }
}
