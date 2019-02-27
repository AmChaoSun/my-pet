using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyPet.Data;
using MyPet.Data.Interfaces;
using MyPet.Models;
using MyPet.Models.DTOs;
using Xunit;

namespace MyPet.Test.Repositories
{
    public class UserRepoTest
    {
        private readonly IUserRepository userRepository;
        public UserRepoTest()
        {
            var options = new DbContextOptionsBuilder<MyPetContext>()
                .UseInMemoryDatabase(databaseName: "MyPet")
                .Options;
            MyPetContext myPetContextt = new MyPetContext(options);
            myPetContextt.Database.EnsureDeleted();
            myPetContextt.Database.EnsureCreated();
            userRepository = new UserRepository(myPetContextt);
        }

        [Fact]
        public void RegularAddUser()
        {
            var zak = new User 
            {
                UserName = "zak",
                Email = "123@example.com",
                Password = "12345678",
                CreatedOn = DateTime.Parse("Jan 1, 2009")
            };
            var savedUser = userRepository.Add(zak);
            Assert.Equal(1, userRepository.GetAll().Count());
            Assert.Equal("zak", savedUser.UserName);

        }
    }
}
