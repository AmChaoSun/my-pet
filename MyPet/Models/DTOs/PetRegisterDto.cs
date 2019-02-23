using System;
using System.ComponentModel.DataAnnotations;

namespace MyPet.Models.DTOs
{
    public class PetRegisterDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} length must not exceed {1}.")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
        public double? Weight { get; set; }
        public decimal? WeightRateToFeed { get; set; }
        public int? MealsPerDay { get; set; }
        public int OwnerId { get; set; }
    }
}
