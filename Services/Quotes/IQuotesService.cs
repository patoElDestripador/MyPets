using MyPets.Model;
using MyPets.Utils;

namespace MyPets.Services.Quotes
{
    public interface IQuotesService
    {
        Task<IEnumerable<Quote>> GetAllQuotesAsync();
        Task<Quote> GetQuotesByIdAsync(int id);
        Task<ResponseUtils<Quote>> CreateQuoteAsync(QuoteDTO Quote);
        Task<ResponseUtils<Quote>> UpdateQuoteAsync(int id,QuoteDTO Quote);
    }
}