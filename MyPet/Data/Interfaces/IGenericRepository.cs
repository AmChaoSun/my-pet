using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyPet.Models;

namespace MyPet.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        DbSet<T> Records { get; }
        IEnumerable<T> GetAll();
        T Add(T record);
        T GetById(int id);
        T Update(T record);
        void Delete(T record);
    }
}
