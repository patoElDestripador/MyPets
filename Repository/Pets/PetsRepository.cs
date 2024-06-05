using MyPets.Data;
using MyPets.Model;
using Microsoft.EntityFrameworkCore;

namespace MyPets.Repository.Pets
{
    public class PetsRepository : IPetsRepository
    {
        private readonly MyPetsDbContext _dbContext;

        public PetsRepository(MyPetsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Pet> CreatePetAsync( Pet pet)
        {
            await _dbContext.Pets.AddAsync(pet);
            await _dbContext.SaveChangesAsync();
            return pet;
        }

        public async Task<IEnumerable<Pet>> GetAllPetsAsync()
        {
            return await _dbContext.Pets.Include(e => e.Owner).ToListAsync();
        }

        public async Task<Pet> GetPetsByIdAsync(int id)
        {
            return await _dbContext.Pets.Include(e => e.Owner).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Pet> UpdatePetAsync(Pet pet)
        {
            _dbContext.Entry(pet).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return pet;
        }
    }
}