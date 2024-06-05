using Microsoft.AspNetCore.Mvc;
using MyPets.Model;
using MyPets.Services.Vets;
using MyPets.Utils;

namespace MyPets.Controller.Vets
{
    [ApiController]
    [Route("api/Vets")]
    public class CreateVetController : ControllerBase
    {
        private readonly IVetsService _Vetservice;

        public CreateVetController(IVetsService Vetservice)
        {
            _Vetservice = Vetservice;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseUtils<Vet>>> Post([FromBody] VetDTO Vet)
        {
            var result = await _Vetservice.CreateVetAsync(Vet);
            if (!result.Status)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}