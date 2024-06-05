using MyPets.Model;
using MyPets.Repository.Vets;
using MyPets.Utils;

namespace MyPets.Services.Vets
{
    public class VetsService : IVetsService
    {
        private readonly IVetsRepository _VetsRepository;

        public VetsService(IVetsRepository VetsRepository)
        {
            _VetsRepository = VetsRepository;
        }

        public async Task<ResponseUtils<Vet>> CreateVetAsync(VetDTO vetDTO)
        {
            var vet = new Vet()
            {
                Name = vetDTO.Name,
                Phone = vetDTO.Phone,
                Addres = vetDTO.Addres,
                Email = vetDTO.Email,
            };
            return new ResponseUtils<Vet>(true, new List<Vet> { await _VetsRepository.CreateVetAsync(vet) });
        }

        public async Task<IEnumerable<Vet>> GetAllVetsAsync()
        {
            return await _VetsRepository.GetAllVetsAsync();
        }

        public async Task<Vet> GetVetsByIdAsync(int id)
        {
            return await _VetsRepository.GetVetsByIdAsync(id);
        }

        public async Task<ResponseUtils<Vet>> UpdateVetAsync(int id, VetDTO vetDTO)
        {
            var vet = new Vet()
            {
                Id = vetDTO.Id ?? id,
                Name = vetDTO.Name,
                Phone = vetDTO.Phone,
                Addres = vetDTO.Addres,
                Email = vetDTO.Email,
            };
            return new ResponseUtils<Vet>(true, new List<Vet> { await _VetsRepository.UpdateVetAsync(vet) });
        }
    }
}