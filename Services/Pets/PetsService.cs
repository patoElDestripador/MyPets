using MyPets.Model;
using MyPets.Repository.Pets;
using MyPets.Utils;

namespace MyPets.Services.Pets
{
    public class PetsService : IPetsService
    {
        private readonly IPetsRepository _PetsRepository;

        public PetsService(IPetsRepository PetsRepository)
        {
            _PetsRepository = PetsRepository;
        }

        public async Task<ResponseUtils<Pet>> CreatePetAsync(PetDTO petDTO)
        {
            var Pet = new Pet()
            {
                Name = petDTO.Name,
                Specie = petDTO.Specie,
                Race = petDTO.Race,
                DateBirth = petDTO.DateBirth,
                OwnerId = petDTO.OwnerId,
                Photo = petDTO.Photo
            };
            return new ResponseUtils<Pet>(true, new List<Pet> { await _PetsRepository.CreatePetAsync(Pet) });
        }

        public async Task<IEnumerable<Pet>> GetAllPetsAsync()
        {
            return await _PetsRepository.GetAllPetsAsync();
        }

        public async Task<Pet> GetPetsByIdAsync(int id)
        {
            return await _PetsRepository.GetPetsByIdAsync(id);
        }

        public async Task<ResponseUtils<Pet>> UpdatePetAsync(int id, PetDTO petDTO)
        {
            var Pet = new Pet()
            {
                Id = petDTO.Id ?? id,
                Name = petDTO.Name,
                Specie = petDTO.Specie,
                Race = petDTO.Race,
                DateBirth = petDTO.DateBirth,
                OwnerId = petDTO.OwnerId,
                Photo = petDTO.Photo
            };
            return new ResponseUtils<Pet>(true, new List<Pet> { await _PetsRepository.UpdatePetAsync(Pet) });
        }
    }
}