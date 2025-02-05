using api.DTOs.Category;
using api.Models;
using api.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [ApiController]
    [Route("Category")]

    public class CategoryController: ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService us)
        {
            this.categoryService = us;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<ServiceResponse<Category>>> Insert(UpsertCategoryDTO data)
        {
            return Ok(await categoryService.Insert(data));
        }

        [HttpPut("Update/{Id}")]
        public async Task<ActionResult<ServiceResponse<Category>>> Update(int Id,UpsertCategoryDTO data)
        {
            return Ok(await categoryService.Update(Id,data));
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int Id)
        {
            return Ok(await categoryService.Delete(Id));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetAll()
        {
            return Ok(await categoryService.GetAll());
        }

        [HttpGet("GetById/{Id}")]
        public async Task<ActionResult<ServiceResponse<Category>>> GetById(int Id)
        {
            return Ok(await categoryService.GetById(Id));
        }

    }
}
