using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Posting
{
    public class UpsertPostingDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int CityId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int TypeId { get; set; }

        public bool IsPublic { get; set; } = true;
    }
}

