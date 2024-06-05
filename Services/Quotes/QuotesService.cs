using System.Globalization;
using MyPets.Model;
using MyPets.Repository.Owners;
using MyPets.Repository.Pets;
using MyPets.Repository.Quotes;
using MyPets.Services.ExternalApis;
using MyPets.Services.Owners;
using MyPets.Services.Pets;
using MyPets.Utils;

namespace MyPets.Services.Quotes
{
    public class QuotesService : IQuotesService
    {
        private readonly IQuotesRepository _QuotesRepository;
        private readonly IMailSenderApiService _mailSenderApiService;
        private readonly IPetsRepository _petsRepository;

        public QuotesService(IQuotesRepository QuotesRepository, IMailSenderApiService mailSenderApiService, IPetsRepository petsRepository)
        {
            _QuotesRepository = QuotesRepository;
            _mailSenderApiService = mailSenderApiService;
            _petsRepository = petsRepository;
        }

        public async Task<ResponseUtils<Quote>> CreateQuoteAsync(QuoteDTO quoteDTO)
        {
            var quote = new Quote()
            {
                Date = quoteDTO.Date,
                PetId = quoteDTO.PetId,
                VetId = quoteDTO.VetId,
            };
            var createQuote = await _QuotesRepository.CreateQuoteAsync(quote);
            var owner = await _petsRepository.GetPetsByIdAsync(quoteDTO.PetId);

            Console.WriteLine("owner.Owner.Email");
            Console.WriteLine(owner.Owner.Email);
            Console.WriteLine("antes de ir al mail sender");
            var mail = await _mailSenderApiService.SendMailAsync(owner.Owner.Email, createQuote.Id, owner.Owner.Names, $"{createQuote.Date}", "2:00 PM");

            if (!mail)
            {
                return new ResponseUtils<Quote>(false, new List<Quote> { createQuote });
            }
            return new ResponseUtils<Quote>(true, new List<Quote> { createQuote });
        }

        public async Task<IEnumerable<Quote>> GetAllQuotesAsync()
        {
            return await _QuotesRepository.GetAllQuotesAsync();
        }

        public async Task<Quote> GetQuotesByIdAsync(int id)
        {
            return await _QuotesRepository.GetQuotesByIdAsync(id);
        }

        public async Task<ResponseUtils<Quote>> UpdateQuoteAsync(int id, QuoteDTO quoteDTO)
        {
            var quote = new Quote()
            {
                Id = quoteDTO.Id ?? id,
                Date = quoteDTO.Date,
                PetId = quoteDTO.PetId,
                VetId = quoteDTO.VetId,
            };
            return new ResponseUtils<Quote>(true, new List<Quote> { await _QuotesRepository.UpdateQuoteAsync(quote) });
        }

        public async Task<ResponseUtils<Quote>> GetQuotesByDayAsync(string request)
        {
            if (DateOnly.TryParseExact(request, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly dateValue))
            {
                var existinDay = await _QuotesRepository.GetQuotesByDayAsync(dateValue);
                if (existinDay == null)
                {

                    return new ResponseUtils<Quote>(true, new List<Quote>(existinDay), message: "no se encontro nah");
                }
                return new ResponseUtils<Quote>(true, new List<Quote>(existinDay));
            }
            return new ResponseUtils<Quote>(false, message: "La fecha es inválida");
        }

        public async Task<ResponseUtils<Quote>> GetQuotesByVetIdAsync(int id)
        {
            var existinId = await _QuotesRepository.GetQuotesByVetIdAsync(id);
            if (existinId == null)
            {
                return new ResponseUtils<Quote>(true, new List<Quote>(existinId), message: "no se encontro nah");
            }
            return new ResponseUtils<Quote>(true, new List<Quote>(existinId));
        }
    }
}