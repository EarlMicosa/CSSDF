using PetManager.Model;

namespace PetManager.Manager
{
    public class PetManagers : PetServices
    {

        private readonly PetContext _context;
        public PetManagers(PetContext context)
        {
            _context = context;
        }
        public IEnumerable<Pet> GetAllPets()
        {
            return _context.Pets.ToList();
        }

        public Pet GetPetById(int id)
        {
            foreach (var Pet in _context.Pets)
            {
                if (id == Pet.PetId)
                {
                    return Pet;
                }
            }
            return null;
        }

        public void AddPet(Pet Pet)
        {
            _context.Pets.Add(Pet);
            _context.SaveChanges();
        }
        public void UpdatePet(int id, Pet Pet)
        {
            foreach (var e in _context.Pets)
            {
                if (id == e.PetId)
                {
                    e.FirstName = Pet.FirstName;
                    e.breed = Pet.breed;
                    e.Age = Pet.Age;
                    _context.SaveChanges();
                    return;
                }
            }
        }
        public void DeletePet(int id)
        {
            foreach (var Pet in _context.Pets)
            {
                if (id == Pet.PetId)
                {
                    _context.Pets.Remove(Pet);
                    _context.SaveChanges();
                }
            }
        }
    }
}
