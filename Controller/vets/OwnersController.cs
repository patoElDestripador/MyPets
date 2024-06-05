using Microsoft.AspNetCore.Mvc;
using MyPets.Model;
using MyPets.Services.Vets;
using MyPets.Utils;

namespace MyPets.Controller.Vets
{
    [ApiController]
    [Route("api/Vets")]
    public class VetsController : ControllerBase
    {
        private readonly IVetsService _Vetservice;

        public VetsController(IVetsService Vetservice)
        {
            _Vetservice = Vetservice;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseUtils<Vet>>> GetAllVetsAsync()
        {
            var vets = await _Vetservice.GetAllVetsAsync();
            return Ok(new ResponseUtils<Vet>(true, new List<Vet>(vets)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseUtils<Vet>>> GetVetsByIdAsync(int id)
        {
            var vets = await _Vetservice.GetVetsByIdAsync(id);
            return Ok(new ResponseUtils<Vet>(true, new List<Vet> { vets }));
        }

    }
}