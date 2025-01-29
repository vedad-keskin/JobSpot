using api.DTOs.Country;
using api.Models;

namespace api.Services.UserServices
{
    public interface ICountryService
    {
        Task<ServiceResponse<Country>> Insert(UpsertCountryDto data);

    }
}

