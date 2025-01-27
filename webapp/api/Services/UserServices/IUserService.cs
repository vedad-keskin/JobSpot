using System;
using api.Models;
using api.DTOs.User;

namespace api.Services.UserServices
{
    public interface IUserService
    {
        Task<ServiceResponse<bool>> Register(RegisterDto data);
        Task<ServiceResponse<UserDto>> Login(LoginDto data);
        Task<ServiceResponse<UserDto>> GetUserById(int id);
        Task<ServiceResponse<UserDto>> ConfirmEmail(string token);
        Task<ServiceResponse<bool>> SendResetPasswordEmail(string email);
        Task<ServiceResponse<UserDto>> SetNewPassword(NewPasswordDto passwordDto);
        Task<ServiceResponse<UserDto>> AssignAdmin(int userId);
        Task<ServiceResponse<UserDto>> RevokeAdmin(int userId);
    }
}

