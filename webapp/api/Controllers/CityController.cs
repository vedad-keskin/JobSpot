using System;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.DTOs.User;
using api.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using api.DTOs.City;

namespace api.Controllers
{
    [ApiController]
    [Route("City")]
    public class CityController : ControllerBase
    {
        private readonly ICityService cityService;

        public CityController(ICityService us)
        {
            this.cityService = us;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<ServiceResponse<City>>> Insert(UpsertCityDto data)
        {
            return Ok(await cityService.Insert(data));
        }

        [HttpPut("Update/{Id}")]
        public async Task<ActionResult<ServiceResponse<City>>> Update(int Id, UpsertCityDto data)
        {
            return Ok(await cityService.Update(Id, data));
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int Id)
        {
            return Ok(await cityService.Delete(Id));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<City>>>> GetAll()
        {
            return Ok(await cityService.GetAll());
        }

        [HttpGet("GetById/{Id}")]
        public async Task<ActionResult<ServiceResponse<City>>> GetById(int Id)
        {
            return Ok(await cityService.GetById(Id));
        }



    }
}

