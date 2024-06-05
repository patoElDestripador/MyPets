using Microsoft.AspNetCore.Mvc;
using MyPets.Model;
using MyPets.Services.Pets;
using MyPets.Utils;

namespace MyPets.Controller.Pets
{
    [ApiController]
    [Route("api/Pets")]
    public class UpdatePetController : ControllerBase
    {
        private readonly IPetsService _Petservice;

        public UpdatePetController(IPetsService Petservice)
        {
            _Petservice = Petservice;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseUtils<Pet>>> UpdatePetAsync(int id, PetDTO PetDTO)
        {
            var response = await _Petservice.UpdatePetAsync(id, PetDTO);
            return Ok(response);
        }
    }
}