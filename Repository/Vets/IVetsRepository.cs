using MyPets.Model;

namespace MyPets.Repository.Vets
{
    public interface IVetsRepository
    {
        Task<IEnumerable<Vet>> GetAllVetsAsync();
        Task<Vet> GetVetsByIdAsync(int id);
        Task<Vet> CreateVetAsync(Vet vet);
        Task<Vet> UpdateVetAsync(Vet vet);
    }
}