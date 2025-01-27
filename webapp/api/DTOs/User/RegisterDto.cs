using System;
using System.ComponentModel.DataAnnotations;
namespace api.DTOs.User
{
    public class RegisterDto
    {

        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; } = String.Empty;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [MinLength(8, ErrorMessage = "Minimum 8 characters")]
        public string Password { get; set; } = String.Empty;

        [Required(ErrorMessage = "Password confirmation is required!")]
        [Compare("Password", ErrorMessage = "Passwords doesn't match!")]
        public string ConfirmPassword { get; set; } = String.Empty;

    }
}

