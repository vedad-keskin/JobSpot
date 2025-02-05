using api.DTOs.Category;
using api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services.CategoryService
{
    public class CategoryService: ICategoryService
    {

        private readonly DBContext db;
        private readonly IMapper mapper;


        public CategoryService(DBContext _db,IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;

        }

        public async Task<ServiceResponse<Category>> Insert(UpsertCategoryDTO data)
        {
            ServiceResponse<Category> sr = new();

            bool categoryExists = await db.Categories.AnyAsync(c => c.Title.ToLower() == data.Title.ToLower());
            if (categoryExists)
            {
                sr.Success = false;
                sr.Message = "Category with this title already exists.";
                return sr;
            }

            Category newCategory = mapper.Map<Category>(data);

            db.Categories.Add(newCategory);
            await db.SaveChangesAsync();

            sr.Success = true;
            sr.Message = "Category added successfully.";
            sr.Data = newCategory;

            return sr;
        }

        public async Task<ServiceResponse<Category>> Update(int Id,UpsertCategoryDTO data)
        {
            ServiceResponse<Category> sr = new();

            Category? existingCategory = await db.Categories.FindAsync(Id);


            if (existingCategory == null)
            {
                sr.Success = false;
                sr.Message = "Category not found.";
                return sr;
            }

            bool titleExists = await db.Categories.AnyAsync(c => c.Id != Id && c.Title.ToLower() == data.Title.ToLower());
            if (titleExists)
            {
                sr.Success = false;
                sr.Message = "Category with this title already exists.";
                return sr;
            }

            existingCategory = mapper.Map(data,existingCategory);

            db.Categories.Update(existingCategory);
            await db.SaveChangesAsync();

            sr.Success = true;
            sr.Message = "Category updated successfully.";
            sr.Data = existingCategory;

            return sr;
        }

        public async Task<ServiceResponse<bool>> Delete(int Id)
        {
            ServiceResponse<bool> sr = new();

            Category? existingCategory = await db.Categories.FindAsync(Id);

            if (existingCategory == null)
            {
                sr.Success = false;
                sr.Message = "Category not found.";
                sr.Data = false;
                return sr;
            }

            db.Categories.Remove(existingCategory);
            await db.SaveChangesAsync();

            sr.Success = true;
            sr.Message = "Category deleted successfully.";
            sr.Data = true;

            return sr;
        }

        public async Task<ServiceResponse<List<Category>>> GetAll()
        {
            ServiceResponse<List<Category>> sr = new();

            var categories = await db.Categories.ToListAsync();

            sr.Success = true;
            sr.Message = "Categories fetched successfully.";
            sr.Data = categories;

            return sr;
        }

        public async Task<ServiceResponse<Category>> GetById(int Id)
        {
            ServiceResponse<Category> sr = new();

            Category? category = await db.Categories.FindAsync(Id);

            if (category == null)
            {
                sr.Success = false;
                sr.Message = "Category not found.";
                return sr;
            }

            sr.Success = true;
            sr.Message = "Category retrieved successfully.";
            sr.Data = category;

            return sr;
        }
    }
}
