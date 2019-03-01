using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPet.Data;
using MyPet.Managers;
using MyPet.Managers.Interfaces;
using MyPet.Models;
using MyPet.Models.DTOs;
using MyPet.Test.TestData;
using MyPet.Utils;
using Xunit;

namespace MyPet.Test.Managers
{
    public class UserManagerTest
    {
        private readonly IMapper mapper;
        public UserManagerTest()
        {
            //init automapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            mapper = config.CreateMapper();
        }

        //success create user cases
        [Theory]
        [ClassData(typeof(UserCreateTestData))]
        public void CreateUser(UserRegisterDto newUser, int id, string userName, string email)
        {
            //set up a in-memory-test-db
            var options = new DbContextOptionsBuilder<MyPetContext>()
                .UseInMemoryDatabase("Add_users_to_db")
                .Options;

            //init context
            using (var myPetContext = new MyPetContext(options)) {
                var userRepository = new UserRepository(myPetContext);
                var userManager = new UserManager(userRepository, mapper);
                UserDisplayDto createdUser = userManager.CreateUser(newUser);

                //verify properties
                Assert.Equal(id, myPetContext.Users.Count());
                Assert.Equal(userName, createdUser.UserName);
                Assert.Equal(email, createdUser.Email);
            }
        }

        //existed User name 
        [Fact]
        public void UserInfoExisted()
        {

            //init settings
            var options = new DbContextOptionsBuilder<MyPetContext>()
                .UseInMemoryDatabase("Add_users_with_duplicate_to_db")
                .Options;

            //// Run the test against one instance of the context
            using (var myPetContext = new MyPetContext(options))
            {
                var userRepository = new UserRepository(myPetContext);
                var userManager = new UserManager(userRepository, mapper);

                // init a new register 
                var user = new UserRegisterDto
                {
                    UserName = "charles",
                    Email = "123@example.com",
                    Password = "123456",
                    ConfirmPassword = "123456"
                };

                //add a user
                userManager.CreateUser(user);
                Assert.Single(myPetContext.Users);
            }

            // Use separate instances of the context to verify duplicated user
            //duplicated name
            using (var myPetContext = new MyPetContext(options))
            {
                var userRepository = new UserRepository(myPetContext);
                var userManager = new UserManager(userRepository, mapper);

                //create user with duplicated name
                var nameExisteduser = new UserRegisterDto
                {
                    UserName = "charles",
                    Email = "1234@example.com",
                    Password = "123456",
                    ConfirmPassword = "123456"
                };
                //add a user with the same username
                Assert.Throws<CustomDbConflictException>(() => userManager.CreateUser(nameExisteduser));
            }

            //duplicated email
            using (var myPetContext = new MyPetContext(options))
            {
                var userRepository = new UserRepository(myPetContext);
                var userManager = new UserManager(userRepository, mapper);

                //create user with duplicated email
                var emailExisteduser = new UserRegisterDto
                {
                    UserName = "julie",
                    Email = "123@example.com",
                    Password = "123456",
                    ConfirmPassword = "123456"
                };
                //add a user with the same username
                Assert.Throws<CustomDbConflictException>(() => userManager.CreateUser(emailExisteduser));
            }
                
        }
    }
}
