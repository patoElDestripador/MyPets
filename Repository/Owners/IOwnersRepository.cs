using MyPets.Model;

namespace MyPets.Repository.Owners
{
    public interface IOwnersRepository
    {
        Task<IEnumerable<Owner>> GetAllOwnersAsync();
        Task<Owner> GetOwnersByIdAsync(int id);
        Task<Owner> CreateOwnerAsync(Owner owner);
        Task<Owner> UpdateOwnerAsync(Owner owner);
    }
}