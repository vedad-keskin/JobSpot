using api.DTOs.Posting;
using api.Models;

namespace api.Services.UserServices
{
    public interface IPostingService
    {
        Task<ServiceResponse<Posting>> Insert(UpsertPostingDto data);
        Task<ServiceResponse<Posting>> Update(int Id,UpsertPostingDto data);
        Task<ServiceResponse<bool>> Delete(int Id);
        Task<ServiceResponse<List<Posting>>> GetAll();
        Task<ServiceResponse<Posting>> GetById(int Id);
    }
}



