using MyPets.Model;
using MyPets.Utils;

namespace MyPets.Services.Pets
{
    public interface IPetsService
    {
        Task<IEnumerable<Pet>> GetAllPetsAsync();
        Task<Pet> GetPetsByIdAsync(int id);
        Task<ResponseUtils<Pet>> CreatePetAsync(PetDTO Pet);
        Task<ResponseUtils<Pet>> UpdatePetAsync(int id, PetDTO Pet);
        Task<IEnumerable<Pet>> GetPetsByOwnerIdAsync(int id);
        Task<ResponseUtils<Pet>> GetPetsByBirthDateAsync(string request);

    }
}