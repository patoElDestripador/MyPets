using Microsoft.AspNetCore.Mvc;
using MyPets.Model;
using MyPets.Services.Owners;
using MyPets.Utils;

namespace MyPets.Controller.Owners
{
    [ApiController]
    [Route("api/owners")]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnersService _ownerservice;

        public OwnersController(IOwnersService ownerservice)
        {
            _ownerservice = ownerservice;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseUtils<Owner>>> GetAllOwnersAsync()
        {
            var owners = await _ownerservice.GetAllOwnersAsync();
            return Ok(new ResponseUtils<Owner>(true, new List<Owner>(owners)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseUtils<Owner>>> GetOwnersByIdAsync(int id)
        {
            var owners = await _ownerservice.GetOwnersByIdAsync(id);
            return Ok(new ResponseUtils<Owner>(true, new List<Owner> { owners }));
        }

    }
}