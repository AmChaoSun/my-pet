using System;
using System.Linq;
using MyPet.Data.Interfaces;
using MyPet.Models;

namespace MyPet.Data
{
    public class PetRepository : GenericRepository<Pet>, IPetRepository
    {
        public PetRepository(MyPetContext context) : base(context)
        {
        }

        public override Pet Add(Pet record)
        {
            if(context.Pets
                .Where(x => x.Owner == record.Owner)
                .Any(x => x.Name == record.Name))
            {
                return null;
            }
            return base.Add(record);
        }

        public override void Delete(Pet record)
        {
            if(!context.Pets.Any(x => x.PetId == record.PetId))
            {
                return;
            }
            base.Delete(record);
        }

        public override Pet Update(Pet record)
        {
            if (context.Pets
                .Where(x => x.Owner == record.Owner)
                .Any(x => x.Name == record.Name))
            {
                return null;
            }
            return base.Update(record);
        }
    }
}
