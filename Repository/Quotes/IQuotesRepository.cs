using MyPets.Model;

namespace MyPets.Repository.Quotes
{
    public interface IQuotesRepository
    {
        Task<IEnumerable<Quote>> GetAllQuotesAsync();
        Task<Quote> GetQuotesByIdAsync(int id);
        Task<Quote> CreateQuoteAsync(Quote quote);
        Task<Quote> UpdateQuoteAsync(Quote quote);
        Task<List<Quote>> GetQuotesByDayAsync(DateOnly date);
        Task<List<Quote>> GetQuotesByVetIdAsync(int id);
  
    }
}