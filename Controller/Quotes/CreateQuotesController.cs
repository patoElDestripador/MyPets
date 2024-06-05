using Microsoft.AspNetCore.Mvc;
using MyPets.Model;
using MyPets.Services.Quotes;
using MyPets.Utils;

namespace MyPets.Controller.Quotes
{
    [ApiController]
    [Route("api/quotes")]
    public class CreateQuoteController : ControllerBase
    {
        private readonly IQuotesService _Quoteservice;

        public CreateQuoteController(IQuotesService Quoteservice)
        {
            _Quoteservice = Quoteservice;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseUtils<Quote>>> Post([FromBody] QuoteDTO quote)
        {
            var result = await _Quoteservice.CreateQuoteAsync(quote);
            if (!result.Status)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}