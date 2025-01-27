using System;
using api.DTOs.User;
using api.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Claims;
using api.Services.EmailService;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace api.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly DBContext db;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IEmailService emailService;

        public UserService(DBContext _db, IMapper _mapper, IConfiguration _configuration, IEmailService _emailService)
        {
            db = _db;
            mapper = _mapper;
            configuration = _configuration;
            emailService = _emailService;
        }

        public async Task<ServiceResponse<UserDto>> ConfirmEmail(string token)
        {
            ServiceResponse<UserDto> sr = new();
            var tokenHandler = new JwtSecurityTokenHandler();
            string? secret = Environment.GetEnvironmentVariable("email_confirmation_secret");
            if (secret == null || secret == "")
            {
                sr.Success = false;
                sr.Message = "Invalid secret";
                sr.Data = null;
                return sr;
            }
            TokenDto tokenData = User.ValidateToken(secret, token);

            User user = await db.Users.FirstAsync(u => u.Id == tokenData.UserId);
            if (user == null)
            {
                sr.Success = false;
                sr.Message = "User doesn't exist";
                return sr;
            }
            user.EmailConfirmed = true;
            await db.SaveChangesAsync();
            sr.Success = true;
            sr.Message = "Email confirmed";
            sr.Data = mapper.Map<UserDto>(user);
            return sr;
        }

        public async Task<ServiceResponse<UserDto>> GetUserById(int id)
        {
            User? user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
          
            ServiceResponse<UserDto> sr = new();

            if (user == null) {
                sr.Success = false;
                sr.Message = "No user!";
            }
            else
            {
                sr.Success = true;
                sr.Data = mapper.Map<UserDto>(user);
            }

            return sr;
        }

        public async Task<ServiceResponse<UserDto>> Login(LoginDto data)
        {
            ServiceResponse<UserDto> sr = new();
            User? user = await db.Users.FirstOrDefaultAsync(u => u.Email == data.Email);
          
            if (user == null || !BCrypt.Net.BCrypt.Verify(data.Password, user.Password))
            {
                sr.Success = false;
                sr.Message = "Invalid credentials!";
                return sr;
            }
            if (user.EmailConfirmed != true)
            {
                sr = SendConfirmationEmail(user, sr);

                sr.Success = false;
                sr.Message = "Please confirm your email!";
                return sr;
            }
            sr.Success = true;
            sr.Message = "Login successfull!";
            sr.Data = mapper.Map<UserDto>(user);
            string secret = configuration["Jwt:Secret"] ?? "";
            sr.Token = user.GenerateToken(secret);
            return sr;
        }

        public async Task<ServiceResponse<bool>> Register(RegisterDto data)
        {
            var user = new User
            {
                Email = data.Email,
                FirstName = data.FirstName ?? "",
                LastName = data.LastName ?? "",
                Password = data.Password
            };
            db.Users.Add(user);
            await db.SaveChangesAsync();
            var sr = new ServiceResponse<bool>
            {
                Data =true,
                Success = true,
                Message = "Succesfully registered!"
            };

            sr = SendConfirmationEmail(user, sr);

            return sr;
        }

        public async Task<ServiceResponse<UserDto>> AssignAdmin(int userId)
        {
            ServiceResponse<UserDto> sr = new();
            User? user = await db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null) {
                sr.Message = $"Cannot find user with id {userId}";
                sr.Success = false;
                return sr;
            }
            if (user.IsAdmin == true)
            {
                sr.Message = $"User already admin: {user.Email}";
                sr.Success = true;
                return sr;
            }
            user.IsAdmin = true;
            await db.SaveChangesAsync();
            sr.Data = mapper.Map<UserDto>(user);
            sr.Message = $"Admin assigned to user {user.Email}";
            sr.Success = true;
            return sr;
        }

        public async Task<ServiceResponse<UserDto>> RevokeAdmin(int userId)
        {
            ServiceResponse<UserDto> sr = new();
            User? user = await db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                sr.Message = $"Cannot find user with id {userId}";
                sr.Success = false;
                return sr;
            }
            if (user.IsAdmin == false)
            {
                sr.Message = $"User is not admin: {user.Email}";
                sr.Success = true;
                return sr;
            }
            user.IsAdmin = false;
            await db.SaveChangesAsync();
            sr.Data = mapper.Map<UserDto>(user);
            sr.Message = $"Admin revoked from user {user.Email}";
            sr.Success = true;
            return sr;
        }

        private ServiceResponse<T> SendConfirmationEmail<T>(User user, ServiceResponse<T> sr)
        {

            string? secret = Environment.GetEnvironmentVariable("email_confirmation_secret");
            if (secret == null || secret == "")
            {
                sr.Success = false;
                sr.Message = "Invalid secret";
                sr.Data = default;
                return sr;
            }
            string verificationToken = user.GenerateToken(secret);
            string host = Environment.GetEnvironmentVariable("api_url")!;
            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat("<h1>User Registered</h1>");
            mailBody.AppendFormat("<br />");
            mailBody.AppendFormat("<p>Please confirm registration by clicking link below</p>");
            mailBody.AppendFormat($"<a href='{host}/user/confirm_email/{verificationToken}'>Confirm Registration</a>");
            emailService.SendEmail(user.Email, "JobSpot Registration", mailBody);
            return sr;
        }

        public async Task<ServiceResponse<bool>> SendResetPasswordEmail(string email)
        {
            ServiceResponse<bool> sr = new();

            string? secret = Environment.GetEnvironmentVariable("email_confirmation_secret");
            if (secret == null || secret == "")
            {
                sr.Success = false;
                sr.Message = "Invalid secret";
                sr.Data = false;
                return sr;
            }
            User? user = await db.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null )
            {
                sr.Success = false;
                sr.Message = "User doesn't exist";
                sr.Data = false;
                return sr;
            }
            string verificationToken = user.GenerateToken(secret, 5);
            string frontend_url = Environment.GetEnvironmentVariable("frontend_url")!;
            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat("<h1>User requested password reset</h1>");
            mailBody.AppendFormat("<br />");
            mailBody.AppendFormat("<p>Please click on url below to reset password</p>");
            mailBody.AppendFormat($"<a href='{frontend_url}/reset_password/{email}/{verificationToken}'>Reset password</a>");
            emailService.SendEmail(user.Email, "JobSpot Password Reset", mailBody);
            sr.Success = true;
            sr.Message = "Password reset email sent!";
            sr.Data = false;
            return sr;
        }

        public async Task<ServiceResponse<UserDto>> SetNewPassword(NewPasswordDto passwordDto)
        {
            ServiceResponse<UserDto> sr = new();

            string secret = Environment.GetEnvironmentVariable("email_confirmation_secret")!;
            TokenDto tokenData =  User.ValidateToken(secret, passwordDto.Token);
            Console.WriteLine(tokenData);
            User? user = await db.Users.FirstOrDefaultAsync(u => u.Email == tokenData.Email);
            if (user == null)
            {
                sr.Success = false;
                sr.Message = "User doesn't exist";
                return sr;
            }
            user.Password = passwordDto.Password;
            await db.SaveChangesAsync();
            StringBuilder mailBody = new();
            mailBody.AppendFormat("<h1>Password changed/h1>");
            mailBody.AppendFormat("<br />");
            mailBody.AppendFormat($"<p>Password changed for user {user.Email}</p>");

            emailService.SendEmail(user.Email, "JobSpot Password Changed", mailBody);
            sr.Success = true;
            sr.Message = "Password updated!";
            sr.Data = mapper.Map<UserDto>(user);
            return sr;
        }

    }
}

