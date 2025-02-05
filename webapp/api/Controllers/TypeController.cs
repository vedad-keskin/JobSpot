using api.DTOs.ListingType;
using api.Models;
using api.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("Type")]
    public class TypeController: ControllerBase
    {
        private readonly ITypeService typeService;

        public TypeController(ITypeService us)
        {
            this.typeService = us;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<ServiceResponse<Models.Type>>> Insert(UpsertTypeDto data)
        {
            return Ok(await typeService.Insert(data));
        }

        [HttpPut("Update/{Id}")]
        public async Task<ActionResult<ServiceResponse<Models.Type>>> Update(int Id,UpsertTypeDto data)
        {
            return Ok(await typeService.Update(Id,data));
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int Id)
        {
            return Ok(await typeService.Delete(Id));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Models.Type>>>> GetAll()
        {
            return Ok(await typeService.GetAll());
        }

        [HttpGet("GetById/{Id}")]
        public async Task<ActionResult<ServiceResponse<Models.Type>>> GetById(int Id)
        {
            return Ok(await typeService.GetById(Id));
        }

    }
}
