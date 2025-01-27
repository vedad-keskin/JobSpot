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
using api.DTOs.City;
using Sprache;
using System.Collections.Generic;
using IdentityModel;

namespace api.Services.UserServices
{
    public class CityService : ICityService
    {
        private readonly DBContext db;
        private readonly IMapper mapper;


        public CityService(DBContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;

        }

        public async Task<ServiceResponse<bool>> Delete(int Id)
        {
            ServiceResponse<bool> sr = new();

            // Find the city by its ID
            City? existingCity = await db.Cities.FindAsync(Id);

            if (existingCity == null)
            {
                sr.Success = false;
                sr.Message = "City not found.";
                sr.Data = false;
                return sr;
            }

            // Remove the city from the database
            db.Cities.Remove(existingCity);
            await db.SaveChangesAsync();

            // Return success response
            sr.Success = true;
            sr.Message = "City deleted successfully.";
            sr.Data = true;

            return sr;
        }

        public async Task<ServiceResponse<List<City>>> GetAll()
        {
            ServiceResponse<List<City>> sr = new();

            var cities = await db.Cities.ToListAsync();

            // Set the success flag and data
            sr.Success = true;
            sr.Message = "Cities fetched successfully.";
            sr.Data = cities; 

            return sr;
        }

        public async Task<ServiceResponse<City>> GetById(int Id)
        {
            ServiceResponse<City> sr = new();

            // Find the city by its ID
            City? city = await db.Cities.FindAsync(Id);

            // Check if the city exists
            if (city == null)
            {
                sr.Success = false;
                sr.Message = "City not found.";
                return sr;
            }

            // City found, return it in the response
            sr.Success = true;
            sr.Message = "City retrieved successfully.";
            sr.Data = city;

            return sr;
        }

        public async Task<ServiceResponse<City>> Insert(UpsertCityDto data)
        {
            ServiceResponse<City> sr = new();

            bool cityExists = await db.Cities.AnyAsync(c => c.Title.ToLower() == data.Title.ToLower());
            if (cityExists)
            {
                sr.Success = false;
                sr.Message = "A city with this title already exists.";
                return sr;
            }

            City newCity = mapper.Map<City>(data);


            // Add and save the new city to the database
            db.Cities.Add(newCity);
            await db.SaveChangesAsync();

            // Return the newly created city in the response
            sr.Success = true;
            sr.Message = "City added successfully.";
            sr.Data = newCity;

            return sr;
        }

        public async Task<ServiceResponse<City>> Update(int Id, UpsertCityDto data)
        {
            ServiceResponse<City> sr = new();

            // Check if the city exists in the database by its ID
            City? existingCity = await db.Cities.FindAsync(Id);


            if (existingCity == null)
            {
                sr.Success = false;
                sr.Message = "City not found.";
                return sr;
            }

            // Check if another city with the same title exists
            bool titleExists = await db.Cities.AnyAsync(c => c.Id != Id && c.Title.ToLower() == data.Title.ToLower());
            if (titleExists)
            {
                sr.Success = false;
                sr.Message = "A city with this title already exists.";
                return sr;
            }

            // Map the updated data to the existing city entity
            existingCity = mapper.Map(data, existingCity);



            // Update the city in the database
            db.Cities.Update(existingCity);
            await db.SaveChangesAsync();

            // Return the updated city in the response
            sr.Success = true;
            sr.Message = "City updated successfully.";
            sr.Data = existingCity;

            return sr;
        }
    }
}

