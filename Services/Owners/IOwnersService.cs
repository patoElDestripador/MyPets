using MyPets.Model;
using MyPets.Utils;

namespace MyPets.Services.Owners
{
    public interface IOwnersService
    {
        Task<IEnumerable<Owner>> GetAllOwnersAsync();
        Task<Owner> GetOwnersByIdAsync(int id);
        Task<ResponseUtils<Owner>> CreateOwnerAsync(OwnerDTO owner);
        Task<ResponseUtils<Owner>> UpdateOwnerAsync(int id,OwnerDTO owner);
    }
}