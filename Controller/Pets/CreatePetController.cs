using Microsoft.AspNetCore.Mvc;
using MyPets.Model;
using MyPets.Services.Pets;
using MyPets.Utils;

namespace MyPets.Controller.Pets
{
    [ApiController]
    [Route("api/pets")]
    public class CreatePetController : ControllerBase
    {
        private readonly IPetsService _Petservice;

        public CreatePetController(IPetsService Petservice)
        {
            _Petservice = Petservice;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseUtils<Pet>>> Post([FromBody] PetDTO Pet)
        {
            var result = await _Petservice.CreatePetAsync(Pet);
            if (!result.Status)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}