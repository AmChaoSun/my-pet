using System;
using System.Collections.Generic;

namespace MyPet.Models
{
    public partial class Pet
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime CreatedOn { get; set; }
        public int OwnerId { get; set; }
        public double? Weight { get; set; }
        public decimal? WeightRateToFeed { get; set; }
        public int? MealsPerDay { get; set; }

        public virtual User Owner { get; set; }
    }
}
