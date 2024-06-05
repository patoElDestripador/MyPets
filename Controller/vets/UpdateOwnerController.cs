using Microsoft.AspNetCore.Mvc;
using MyPets.Model;
using MyPets.Services.Vets;
using MyPets.Utils;

namespace MyPets.Controller.Vets
{
    [ApiController]
    [Route("api/Vets")]
    public class UpdateVetController : ControllerBase
    {
        private readonly IVetsService _Vetservice;

        public UpdateVetController(IVetsService Vetservice)
        {
            _Vetservice = Vetservice;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseUtils<Vet>>> UpdateVetAsync(int id, VetDTO VetDTO)
        {
            var response = await _Vetservice.UpdateVetAsync(id, VetDTO);
            return Ok(response);
        }
    }
}