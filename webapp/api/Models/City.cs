﻿using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
    }
}
