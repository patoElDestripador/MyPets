using Microsoft.AspNetCore.Mvc;
using MyPets.Model;
using MyPets.Services.Quotes;
using MyPets.Utils;

namespace MyPets.Controller.Quotes
{
    [ApiController]
    [Route("api/quotes")]
    public class UpdateQuoteController : ControllerBase
    {
        private readonly IQuotesService _Quoteservice;

        public UpdateQuoteController(IQuotesService Quoteservice)
        {
            _Quoteservice = Quoteservice;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseUtils<Quote>>> UpdateQuoteAsync(int id, QuoteDTO QuoteDTO)
        {
            var response = await _Quoteservice.UpdateQuoteAsync(id, QuoteDTO);
            return Ok(response);
        }
    }
}