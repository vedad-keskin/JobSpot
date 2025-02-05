using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Category
{
    public class UpsertCategoryDTO
    {
        [Required(ErrorMessage = "Category name is required!")]
        public string Title { get; set; } = string.Empty;
    }
}
