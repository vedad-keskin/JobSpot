using System;
using System.ComponentModel.DataAnnotations;
namespace api.DTOs.User
{
    public class NewPasswordDto
    {
        [Required(ErrorMessage = "Password is required!")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Token is required!")]
        public required string Token { get; set; }
    }
}

