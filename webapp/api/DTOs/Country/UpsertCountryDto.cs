using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Country
{
    public class UpsertCountryDto
    {
        [Required(ErrorMessage = "Country name is required!")]
        public string Title { get; set; } = string.Empty;
    }
}
