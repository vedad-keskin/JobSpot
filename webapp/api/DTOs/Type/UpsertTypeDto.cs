using System.ComponentModel.DataAnnotations;

namespace api.DTOs.ListingType
{
    public class UpsertTypeDto
    {
        [Required(ErrorMessage = "Type name is required!")]
        public string Title { get; set; } = string.Empty;
    }
}
