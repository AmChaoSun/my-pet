using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<MyPetContext>()
                .UseInMemoryDatabase("UserRepoTestD")
                .UseInternalServiceProvider(serviceProvider)
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
            Assert.Single(userRepository.GetAll());
            Assert.Equal("zak", savedUser.UserName);

        }
    }
}
