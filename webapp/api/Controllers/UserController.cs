using System;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.DTOs.User;
using api.Services.UserServices;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService us)
        {
            this.userService = us;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> Login(LoginDto data)
        {
            return Ok(await userService.Login(data));
        }


        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> Register(RegisterDto user)
        {
            return Ok(await userService.Register(user));
        }

        [HttpGet("confirm_email/{token}")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> ConfirmEmail(string token)
        {
            return Ok(await userService.ConfirmEmail(token));
        }

        [HttpGet("get_user")]
        [Authorize]
        public async Task<ActionResult<string>> getUser()
        {
            var userId = User.FindFirst("id")?.Value;
            if (userId == null) {
                return BadRequest("No userId!");
            }
            return Ok(await userService.GetUserById(int.Parse(userId)));
        }

        [HttpGet("assign_admin/{user_id}")]
        [Authorize(Policy = "IsAdmin")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> AssignAdminRole(int user_id)
        {
            return Ok(await userService.AssignAdmin(user_id));
        }


        [HttpGet("revoke_admin/{user_id}")]
        [Authorize(Policy = "IsAdmin")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> RevokeAdminRole(int user_id)
        {
            return Ok(await userService.RevokeAdmin(user_id));
        }

        [HttpGet("reset_password/{email}")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> ResetPassword(string email)
        {
            return Ok(await userService.SendResetPasswordEmail(email));
        }

        [HttpPatch("set_new_password")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> SetNewPassword(NewPasswordDto passwordDto)
        {
            return Ok(await userService.SetNewPassword(passwordDto));
        }

    }
}

