using System.ComponentModel.DataAnnotations;

namespace api.DTOs.City
{
    public class UpsertCityDto
    {
        [Required(ErrorMessage = "City name is required!")]
        public string Title { get; set; } = string.Empty;
    }
}
