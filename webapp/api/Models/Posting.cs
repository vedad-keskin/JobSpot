using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Posting
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City? City { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User? User { get; set; }

        [Required]
        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }
        public Type? Type { get; set; }

        public bool isPublic { get; set; }

    }
}
