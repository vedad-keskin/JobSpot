using api.DTOs.Category;
using api.Models;

namespace api.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<Category>> Insert(UpsertCategoryDTO data);
        Task<ServiceResponse<Category>> Update(int Id,UpsertCategoryDTO data);
        Task<ServiceResponse<bool>> Delete(int Id);
        Task<ServiceResponse<List<Category>>> GetAll();
        Task<ServiceResponse<Category>> GetById(int Id);
    }
}