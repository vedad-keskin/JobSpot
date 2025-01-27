using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.DTOs.User;
using Microsoft.IdentityModel.Tokens;

namespace api.Models
{
	public class User
	{


		[Key]
		public int Id { get; set; }

		[Required]
		public string Email { get; set; } = string.Empty;

		[Required]
		public string FirstName { get; set; } = String.Empty;

		[Required]
		public string LastName { get; set; } = String.Empty;

		private string _password = String.Empty;

		[Required]
		public string Password
		{
			get => _password;
			set => _password = HashPassword(value);
		}

        [Required]
        public bool EmailConfirmed { get; set; } = false;


        [Required]
        public bool IsAdmin { get; set; } = false;

        private string HashPassword(string password)
		{
			string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
			return BCrypt.Net.BCrypt.HashPassword(password, salt);
		}

        public string GenerateToken(string secret, double? minutes = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", Id.ToString()),
                    new Claim(ClaimTypes.Email, Email),
                    new Claim("isAdmin", IsAdmin.ToString()),
                }),

                Expires = minutes != null ? DateTime.UtcNow.AddMinutes((double)minutes) : DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static TokenDto ValidateToken(string secret, string token) {
            var tokenHandler = new JwtSecurityTokenHandler();

            tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;


                TokenDto tokenData = new TokenDto()
                {
                    Email = jwtToken.Claims.First(claim => claim.Type == "email").Value,
                    UserId = int.Parse(jwtToken.Claims.First(claim => claim.Type == "id").Value),
                    IsAdmin = bool.Parse(jwtToken.Claims.First(claim => claim.Type == "isAdmin").Value),
                };
          
            return tokenData;
        }

	}
}

