using api.DTOs.ListingType;
using api.Models;

namespace api.Services.UserServices
{
    public interface ITypeService
    {

        Task<ServiceResponse<Models.Type>> Insert(UpsertTypeDto data);
        Task<ServiceResponse<Models.Type>> Update(int Id,UpsertTypeDto data);
        Task<ServiceResponse<bool>> Delete(int Id);
        Task<ServiceResponse<List<Models.Type>>> GetAll();
        Task<ServiceResponse<Models.Type>> GetById(int Id);
    }
}

