using MyPets.Model;
using MyPets.Utils;

namespace MyPets.Services.Vets
{
    public interface IVetsService
    {
        Task<IEnumerable<Vet>> GetAllVetsAsync();
        Task<Vet> GetVetsByIdAsync(int id);
        Task<ResponseUtils<Vet>> CreateVetAsync(VetDTO Vet);
        Task<ResponseUtils<Vet>> UpdateVetAsync(int id,VetDTO Vet);
    }
}