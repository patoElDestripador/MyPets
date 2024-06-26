using MyPets.Model;

namespace MyPets.Repository.Pets
{
    public interface IPetsRepository
    {
        Task<IEnumerable<Pet>> GetAllPetsAsync();
        Task<Pet> GetPetsByIdAsync(int id);
        Task<IEnumerable<Pet>> GetPetsByOwnerIdAsync(int id);
        Task<IEnumerable<Pet>> GetPetsByBirthDateAsync(DateOnly date);
        Task<Pet> CreatePetAsync(Pet pet);
        Task<Pet> UpdatePetAsync(Pet pet);
        
    }
}