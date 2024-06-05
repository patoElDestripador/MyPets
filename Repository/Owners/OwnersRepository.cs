using MyPets.Data;
using MyPets.Model;
using Microsoft.EntityFrameworkCore;

namespace MyPets.Repository.Owners
{

    public class OwnersRepository : IOwnersRepository
    {
        private readonly MyPetsDbContext _dbContext;

        public OwnersRepository(MyPetsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Owner> CreateOwnerAsync(Owner owner)
        {
            await _dbContext.Owners.AddAsync(owner);
            await _dbContext.SaveChangesAsync();
            return owner;
        }

        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            return await _dbContext.Owners.ToListAsync();
        }

        public async Task<Owner> GetOwnersByIdAsync(int id)
        {
            return await _dbContext.Owners.FindAsync(id);
        }

        public async Task<Owner> UpdateOwnerAsync(Owner owner)
        {
            _dbContext.Entry(owner).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return owner;
        }
    }
}