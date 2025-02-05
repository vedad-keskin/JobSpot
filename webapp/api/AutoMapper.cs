using api.DTOs.Category;
using api.DTOs.City;
using api.DTOs.Country;
using api.DTOs.ListingType;
using api.DTOs.Posting;
using api.DTOs.User;
using api.Models;
using AutoMapper;

namespace api
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {

            CreateMap<User,UserDto>();
            CreateMap<UserDto,User>();

            CreateMap<User,RegisterDto>();
            CreateMap<RegisterDto,User>();

            CreateMap<UpsertCityDto,City>();

            CreateMap<UpsertCountryDto,Country>();

            CreateMap<UpsertCategoryDTO,Category>();


            CreateMap<UpsertTypeDto,Models.Type>();

            CreateMap<UpsertPostingDto,Posting>();



        }
    }
}

