using Microsoft.AspNetCore.Mvc;
using MyPets.Model;
using MyPets.Services.Quotes;
using MyPets.Utils;

namespace MyPets.Controller.Quotes
{
    [ApiController]
    [Route("api/quotes")]
    public class QuotesController : ControllerBase
    {
        private readonly IQuotesService _Quoteservice;

        public QuotesController(IQuotesService Quoteservice)
        {
            _Quoteservice = Quoteservice;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseUtils<Quote>>> GetAllQuotesAsync()
        {
            var quotes = await _Quoteservice.GetAllQuotesAsync();
            return Ok(new ResponseUtils<Quote>(true, new List<Quote>(quotes)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseUtils<Quote>>> GetQuotesByIdAsync(int id)
        {
            var quotes = await _Quoteservice.GetQuotesByIdAsync(id);
            return Ok(new ResponseUtils<Quote>(true, new List<Quote> { quotes }));
        }

    }
}