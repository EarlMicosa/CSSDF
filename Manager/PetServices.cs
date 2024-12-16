using PetManager.Model;

namespace PetManager.Manager
{

    public interface PetServices
    {
        IEnumerable<Pet> GetAllPets();
        Pet GetPetById(int id);
        void AddPet(Pet Pet);
        void UpdatePet(int id, Pet Pet);
        void DeletePet(int id);
    }
}
