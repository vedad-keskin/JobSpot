using System;
using api.Models;
using api.DTOs.User;
using api.DTOs.City;

namespace api.Services.UserServices
{
    public interface ICityService
    {
        Task<ServiceResponse<City>> Insert(UpsertCityDto data);
        Task<ServiceResponse<City>> Update(int Id, UpsertCityDto data);
        Task<ServiceResponse<bool>> Delete(int Id);

        Task<ServiceResponse<List<City>>> GetAll();
        Task<ServiceResponse<City>> GetById(int Id);


    }
}

