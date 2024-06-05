using MyPets.Data;
using MyPets.Model;
using MyPets.Repository.Vets;
using Microsoft.EntityFrameworkCore;

namespace MyPets.Repository.Owners
{
    public class VetsRepository : IVetsRepository
    {
        private readonly MyPetsDbContext _dbContext;
        public VetsRepository(MyPetsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Vet> CreateVetAsync(Vet vet)
        {
            await _dbContext.Vets.AddAsync(vet);
            await _dbContext.SaveChangesAsync();
            return vet;
        }

        public async Task<IEnumerable<Vet>> GetAllVetsAsync()
        {
            return await _dbContext.Vets.ToListAsync();
        }

        public async Task<Vet> GetVetsByIdAsync(int id)
        {
            return await _dbContext.Vets.FindAsync(id);
        }

        public async Task<Vet> UpdateVetAsync(Vet vet)
        {
            _dbContext.Entry(vet).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return vet;
        }
    }
}