using System;
using System.Collections.Generic;

namespace MyPet.Models
{
    public partial class User
    {
        public User()
        {
            Pets = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
