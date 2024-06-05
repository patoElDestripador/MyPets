using Microsoft.AspNetCore.Mvc;
using MyPets.Model;
using MyPets.Services.Pets;
using MyPets.Utils;

namespace MyPets.Controller.Pets
{
    [ApiController]
    [Route("api/Pets")]
    public class PetsController : ControllerBase
    {
        private readonly IPetsService _Petservice;

        public PetsController(IPetsService Petservice)
        {
            _Petservice = Petservice;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseUtils<Pet>>> GetAllPetsAsync()
        {
            var Pets = await _Petservice.GetAllPetsAsync();
            return Ok(new ResponseUtils<Pet>(true, new List<Pet>(Pets)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseUtils<Pet>>> GetPetsByIdAsync(int id)
        {
            var Pets = await _Petservice.GetPetsByIdAsync(id);
            return Ok(new ResponseUtils<Pet>(true, new List<Pet> { Pets }));
        }

    }
}