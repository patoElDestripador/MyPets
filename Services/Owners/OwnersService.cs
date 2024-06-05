using MyPets.Model;
using MyPets.Repository.Owners;
using MyPets.Utils;

namespace MyPets.Services.Owners
{
    public class OwnersService : IOwnersService
    {
        private readonly IOwnersRepository _ownersRepository;

        public OwnersService(IOwnersRepository ownersRepository)
        {
            _ownersRepository = ownersRepository;
        }

        public async Task<ResponseUtils<Owner>> CreateOwnerAsync(OwnerDTO ownerDTO)
        {
            var owner = new Owner()
            {
                Names = ownerDTO.Names,
                LastNames = ownerDTO.LastNames,
                Email = ownerDTO.Email,
                Addres = ownerDTO.Addres,
                Phone = ownerDTO.Phone,
            };
            return new ResponseUtils<Owner>(true, new List<Owner> { await _ownersRepository.CreateOwnerAsync(owner) });
        }

        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            return await _ownersRepository.GetAllOwnersAsync();
        }

        public async Task<Owner> GetOwnersByIdAsync(int id)
        {
            return await _ownersRepository.GetOwnersByIdAsync(id);
        }

        public async Task<ResponseUtils<Owner>> UpdateOwnerAsync(int id, OwnerDTO ownerDTO)
        {
            var owner = new Owner()
            {
                Id = ownerDTO.Id ?? id,
                Names = ownerDTO.Names,
                LastNames = ownerDTO.LastNames,
                Email = ownerDTO.Email,
                Addres = ownerDTO.Addres,
                Phone = ownerDTO.Phone,
            };
            return new ResponseUtils<Owner>(true, new List<Owner> { await _ownersRepository.UpdateOwnerAsync(owner) });
        }
    }
}

