using api.DTOs.Country;
using api.Models;
using api.Services.CountryService;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("Country")]
    public class CountryController: ControllerBase
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService us)
        {
            this.countryService = us;
        }


        [HttpPost("Insert")]
        public async Task<ActionResult<ServiceResponse<Country>>> Insert(UpsertCountryDto data)
        {
            return Ok(await countryService.Insert(data));
        }

        [HttpPut("Update/{Id}")]
        public async Task<ActionResult<ServiceResponse<Country>>> Update(int Id,UpsertCountryDto data)
        {
            return Ok(await countryService.Update(Id,data));
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int Id)
        {
            return Ok(await countryService.Delete(Id));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Country>>>> GetAll()
        {
            return Ok(await countryService.GetAll());
        }

        [HttpGet("GetById/{Id}")]
        public async Task<ActionResult<ServiceResponse<Country>>> GetById(int Id)
        {
            return Ok(await countryService.GetById(Id));
        }
    }
}
