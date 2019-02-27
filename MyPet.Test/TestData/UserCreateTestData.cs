using System;
using MyPet.Models.DTOs;
using Xunit;

namespace MyPet.Test.TestData
{
    public class UserCreateTestData: TheoryData<UserRegisterDto, int>
    {
        public UserCreateTestData()
        {
            Add(new UserRegisterDto() 
            {
                UserName = "charles",
                Email = "123@example.com",
                Password = "123456",
                ConfirmPassword = "123456"        
            },
                1);
            Add(new UserRegisterDto() 
            {
                UserName = "zak",
                Email = "1235@example.com",
                Password = "123456",
                ConfirmPassword = "123456"        
            },
                2);
            Add(new UserRegisterDto()
            {
                UserName = "julie",
                Email = "1234@example.com",
                Password = "123456",
                ConfirmPassword = "123456"
            },
                3);
        }
    }
}
