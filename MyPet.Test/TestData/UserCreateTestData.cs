using System;
using System.Collections.Generic;
using MyPet.Models.DTOs;
using Xunit;

namespace MyPet.Test.TestData
{
    public class UserCreateTestData: TheoryData<UserRegisterDto, int, string, string>
    {
        public UserCreateTestData()
        {
            //three normal cases
            Add(new UserRegisterDto 
                {
                    UserName = "charles",
                    Email = "123@example.com",
                    Password = "123456",
                    ConfirmPassword = "123456"        
                },
                1, "charles", "123@example.com");
            Add(new UserRegisterDto
                {
                    UserName = "zak",
                    Email = "1235@example.com",
                    Password = "123456",
                    ConfirmPassword = "123456"
                },
                2, "zak", "1235@example.com");
            Add(new UserRegisterDto
                {
                    UserName = "julie",
                    Email = "1234@example.com",
                    Password = "123456",
                    ConfirmPassword = "123456"
                },
                3, "julie", "1234@example.com");
        }
    }
}
