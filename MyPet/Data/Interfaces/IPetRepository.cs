using System;
using MyPet.Models;

namespace MyPet.Data.Interfaces
{
    public interface IPetRepository : IGenericRepository<Pet>
    {
    }
}
