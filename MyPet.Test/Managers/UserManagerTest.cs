using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPet.Data;
using MyPet.Managers;
using MyPet.Managers.Interfaces;
using MyPet.Models;
using MyPet.Models.DTOs;
using MyPet.Test.TestData;
using Xunit;

namespace MyPet.Test.Managers
{
    public class UserManagerTest
    {
        private readonly IUserManager userManager;
        public UserManagerTest()
        {
            //set up a in-memory-test-db
            var options = new DbContextOptionsBuilder<MyPetContext>()
                .UseInMemoryDatabase("UserManagerTestDB")
                .Options;
            MyPetContext myPetContext = new MyPetContext(options);
            myPetContext.Database.EnsureDeleted();
            myPetContext.Database.EnsureCreated();

            //init userManager
            //init userRepository
            var userRepository = new UserRepository(myPetContext);
            //init automapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();
            userManager = new UserManager(userRepository, mapper);
        }

        [Theory]
        [ClassData(typeof(UserCreateTestData))]
        public void createUser(UserRegisterDto newUser, int id)
        {
            UserDisplayDto createdUser = userManager.CreateUser(newUser);
            Assert.Equal(createdUser.Id, id);
        }
    }
}
