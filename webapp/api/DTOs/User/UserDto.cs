using System;
namespace api.DTOs.User
{
	public class UserDto
	{

		public string Email { get; set; } = String.Empty;

		public string FirstName { get; set; } = String.Empty;

		public string LastName { get; set; } = String.Empty;

		public bool IsAdmin { get; set; } = false;
    }
}

