using MyPets.Data;
using MyPets.Model;
using MyPets.Repository.Quotes;
using Microsoft.EntityFrameworkCore;

namespace MyPets.Repository.Owners
{
    public class QuotesRepository : IQuotesRepository
    {
        private readonly MyPetsDbContext _dbContext;

        public QuotesRepository(MyPetsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Quote> CreateQuoteAsync(Quote quote)
        {
            await _dbContext.Quotes.AddAsync(quote);
            await _dbContext.SaveChangesAsync();
            return quote;
        }

        public async Task<IEnumerable<Quote>> GetAllQuotesAsync()
        {
            return await _dbContext.Quotes.Include(e => e.Pet).Include(e => e.Vet).ToListAsync();
        }

        public Task<List<Quote>> GetQuotesByDayAsync(DateOnly date)
        {
            return _dbContext.Quotes.Include(e => e.Pet).Include(e => e.Vet).Where(d => d.Date == date).ToListAsync();
        }

        public async Task<Quote> GetQuotesByIdAsync(int id)
        {
            return await _dbContext.Quotes.Include(e => e.Pet).Include(e => e.Vet).FirstOrDefaultAsync(e => e.Id == id);
        }
        public Task<List<Quote>> GetQuotesByVetIdAsync(int vetId)
        {
            return _dbContext.Quotes.Include(e => e.Pet).Include(e => e.Vet).Where(d => d.VetId == vetId).ToListAsync();
        }

        public async Task<Quote> UpdateQuoteAsync(Quote quote)
        {
            _dbContext.Entry(quote).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return quote;
        }



    }
}