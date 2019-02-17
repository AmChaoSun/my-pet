using System;
using System.ComponentModel.DataAnnotations;

namespace MyPet.Models.DTOs
{
    public class UserRegisterDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} length must not exceed {1}.")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "The {0} length must between {1} and {2}.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and ConfirmPassword must be the same.")]
        public string ConfirmPassword { get; set; }
    }
}
