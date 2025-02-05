using api.DTOs.City;
using api.Models;

namespace api.Services.CityService
{
    public interface ICityService
    {
        Task<ServiceResponse<City>> Insert(UpsertCityDto data);
        Task<ServiceResponse<City>> Update(int Id,UpsertCityDto data);
        Task<ServiceResponse<bool>> Delete(int Id);

        Task<ServiceResponse<List<City>>> GetAll();
        Task<ServiceResponse<City>> GetById(int Id);


    }
}

