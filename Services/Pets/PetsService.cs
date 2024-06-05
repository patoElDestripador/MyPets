using System.Globalization;
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

        public async Task<IEnumerable<Pet>> GetPetsByOwnerIdAsync(int id)
        {
            return await _PetsRepository.GetPetsByOwnerIdAsync(id);
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

        public async Task<ResponseUtils<Pet>> GetPetsByBirthDateAsync(string request)
        {
            if (DateOnly.TryParseExact(request, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly dateValue))
            {
                var existinDay = await _PetsRepository.GetPetsByBirthDateAsync(dateValue);
                if (existinDay == null)
                {

                    return new ResponseUtils<Pet>(true, new List<Pet>(existinDay), message: "no se encontro nah");
                }
                return new ResponseUtils<Pet>(true, new List<Pet>(existinDay));
            }
            return new ResponseUtils<Pet>(false, message: "La fecha es inválida");
        }
    }
}