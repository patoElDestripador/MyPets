using Microsoft.AspNetCore.Mvc;
using MyPets.Model;
using MyPets.Services.Owners;
using MyPets.Utils;

namespace MyPets.Controller.Owners
{
    [ApiController]
    [Route("api/owners")]
    public class UpdateOwnerController : ControllerBase
    {
        private readonly IOwnersService _ownerservice;

        public UpdateOwnerController(IOwnersService ownerservice)
        {
            _ownerservice = ownerservice;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseUtils<Owner>>> UpdateOwnerAsync(int id, OwnerDTO ownerDTO)
        {
            var response = await _ownerservice.UpdateOwnerAsync(id, ownerDTO);
            return Ok(response);
        }
    }
}