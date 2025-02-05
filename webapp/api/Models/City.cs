using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;


        [Required]
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country? Country { get; set; }

    }
}
