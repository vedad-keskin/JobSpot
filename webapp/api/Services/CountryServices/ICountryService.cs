using api.DTOs.Country;
using api.Models;

namespace api.Services.CountryService
{
    public interface ICountryService
    {
        Task<ServiceResponse<Country>> Insert(UpsertCountryDto data);
        Task<ServiceResponse<Country>> Update(int Id,UpsertCountryDto data);
        Task<ServiceResponse<bool>> Delete(int Id);

        Task<ServiceResponse<List<Country>>> GetAll();
        Task<ServiceResponse<Country>> GetById(int Id);

    }
}

