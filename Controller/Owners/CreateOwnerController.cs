using Microsoft.AspNetCore.Mvc;
using MyPets.Model;
using MyPets.Services.Owners;
using MyPets.Utils;

namespace MyPets.Controller.Owners
{
    [ApiController]
    [Route("api/owners")]
    public class CreateOwnerController : ControllerBase
    {
        private readonly IOwnersService _ownerservice;

        public CreateOwnerController(IOwnersService ownerservice)
        {
            _ownerservice = ownerservice;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseUtils<Owner>>> Post([FromBody] OwnerDTO owner)
        {
            var result = await _ownerservice.CreateOwnerAsync(owner);
            if (!result.Status)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}