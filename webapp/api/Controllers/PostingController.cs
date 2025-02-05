using api.DTOs.Posting;
using api.Models;
using api.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("Posting")]
    public class PostingController: ControllerBase
    {
        private readonly IPostingService postingService;

        public PostingController(IPostingService ps)
        {
            this.postingService = ps;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<ServiceResponse<Posting>>> Insert(UpsertPostingDto data)
        {
            return Ok(await postingService.Insert(data));
        }

        [HttpPut("Update/{Id}")]
        public async Task<ActionResult<ServiceResponse<Posting>>> Update(int Id,UpsertPostingDto data)
        {
            return Ok(await postingService.Update(Id,data));
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int Id)
        {
            return Ok(await postingService.Delete(Id));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Posting>>>> GetAll()
        {
            return Ok(await postingService.GetAll());
        }

        [HttpGet("GetById/{Id}")]
        public async Task<ActionResult<ServiceResponse<Posting>>> GetById(int Id)
        {
            return Ok(await postingService.GetById(Id));
        }
    }
}
