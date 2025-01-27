using System;
using System.ComponentModel.DataAnnotations;
namespace api.DTOs.User
{
    public class TokenDto
    {

        public required bool IsAdmin { get; set; }

        public required int UserId { get; set; }

        public required string Email { get; set; }

    }
}

