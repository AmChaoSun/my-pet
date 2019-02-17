using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyPet.Data.Interfaces;
using MyPet.Models;

namespace MyPet.Data
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MyPetContext context) : base(context)
        { 
        }

        public override User Add(User record)
        {
            if (context.Users.Any(x => x.UserName == record.UserName))
            {
                return null;
            }
            return base.Add(record);
        }

        public override void Delete(User record)
        {
            //if (!context.Users.Any(x => x.Id == record.Id))
            //{
            //    return;
            //}
            base.Delete(record);
        }

        public override IEnumerable<User> GetAll()
        {
            var users = context.Users
                .Include(x => x.Pets)
                .ToList();
            return users;
        }

        public override User GetById(int id)
        {
            var user = context.Users
                .Include(x => x.Pets)
                .FirstOrDefault(x => x.Id == id);
            return user;
        }

        public override User Update(User record)
        {
            if (context.Users.Any(x => x.UserName == record.UserName))
            {
                return null;
            }
            return base.Update(record);
        }


    }

}
