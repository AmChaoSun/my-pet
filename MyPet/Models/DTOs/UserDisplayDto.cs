using System;
using System.Collections.Generic;

namespace MyPet.Models.DTOs
{
    public class UserDisplayDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}
