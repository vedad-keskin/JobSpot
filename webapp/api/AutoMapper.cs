using System;
using AutoMapper;
using api.Models;
using api.DTOs.User;
namespace api
{
	public class AutoMapper: Profile
	{
		public AutoMapper()
		{

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<User, RegisterDto>();
            CreateMap<RegisterDto, User>();
        }
	}
}

