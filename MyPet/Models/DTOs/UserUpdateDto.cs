using System;
using System.ComponentModel.DataAnnotations;

namespace MyPet.Models.DTOs
{
    public class UserUpdateDto
    {
        //public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} length must not exceed {1}.")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
