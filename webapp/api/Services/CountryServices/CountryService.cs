using api.DTOs.Country;
using api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services.CountryService
{
    public class CountryService: ICountryService
    {
        private readonly DBContext db;
        private readonly IMapper mapper;

        public CountryService(DBContext _db,IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }


        public async Task<ServiceResponse<Country>> Insert(UpsertCountryDto data)
        {
            ServiceResponse<Country> sr = new();

            bool countryExists = await db.Countries.AnyAsync(c => c.Title.ToLower() == data.Title.ToLower());
            if (countryExists)
            {
                sr.Success = true;
                sr.Message = "Country with this title already exists!";
                return sr;
            }

            Country newCountry = mapper.Map<Country>(data);

            db.Countries.Add(newCountry);
            await db.SaveChangesAsync();

            sr.Success = true;
            sr.Message = "Country added succesfully!";
            sr.Data = newCountry;

            return sr;
        }

        public async Task<ServiceResponse<Country>> Update(int Id,UpsertCountryDto data)
        {
            ServiceResponse<Country> sr = new();

            Country? existingCountry = await db.Countries.FindAsync(Id);


            if (existingCountry == null)
            {
                sr.Success = false;
                sr.Message = "Country not found.";
                return sr;
            }

            bool titleExists = await db.Countries.AnyAsync(c => c.Id != Id && c.Title.ToLower() == data.Title.ToLower());
            if (titleExists)
            {
                sr.Success = false;
                sr.Message = "Country with this title already exists.";
                return sr;
            }

            existingCountry = mapper.Map(data,existingCountry);

            db.Countries.Update(existingCountry);
            await db.SaveChangesAsync();

            sr.Success = true;
            sr.Message = "Country updated successfully.";
            sr.Data = existingCountry;

            return sr;
        }

        public async Task<ServiceResponse<bool>> Delete(int Id)
        {
            ServiceResponse<bool> sr = new();

            // Find the country by its ID
            Country? existingCountry = await db.Countries.FindAsync(Id);

            if (existingCountry == null)
            {
                sr.Success = false;
                sr.Message = "Country not found.";
                sr.Data = false;
                return sr;
            }

            // Remove the country from the database
            db.Countries.Remove(existingCountry);
            await db.SaveChangesAsync();

            // Return success response
            sr.Success = true;
            sr.Message = "Country deleted successfully.";
            sr.Data = true;

            return sr;
        }

        public async Task<ServiceResponse<List<Country>>> GetAll()
        {
            ServiceResponse<List<Country>> sr = new();

            var countries = await db.Countries.ToListAsync();

            // Set the success flag and data
            sr.Success = true;
            sr.Message = "Countries fetched successfully.";
            sr.Data = countries;

            return sr;
        }
        public async Task<ServiceResponse<Country>> GetById(int Id)
        {
            ServiceResponse<Country> sr = new();

            // Find the country by its ID
            Country? country = await db.Countries.FindAsync(Id);

            // Check if the country exists
            if (country == null)
            {
                sr.Success = false;
                sr.Message = "Country not found.";
                return sr;
            }

            // Country found, return it in the response
            sr.Success = true;
            sr.Message = "Country retrieved successfully.";
            sr.Data = country;

            return sr;
        }

    }
}

