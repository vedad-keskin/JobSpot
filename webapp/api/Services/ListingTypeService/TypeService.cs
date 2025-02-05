using api.DTOs.ListingType;
using api.Models;
using api.Services.UserServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services.ListingTypeService
{
    public class TypeService: ITypeService
    {
        private readonly DBContext db;
        private readonly IMapper mapper;


        public TypeService(DBContext _db,IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;

        }
        public async Task<ServiceResponse<Models.Type>> Insert(UpsertTypeDto data)
        {
            ServiceResponse<Models.Type> sr = new();

            bool typeExists = await db.Types.AnyAsync(c => c.Title.ToLower() == data.Title.ToLower());
            if (typeExists)
            {
                sr.Success = false;
                sr.Message = "Type with this title already exists.";
                return sr;
            }

            Models.Type newType = mapper.Map<Models.Type>(data);


            db.Types.Add(newType);
            await db.SaveChangesAsync();

            sr.Success = true;
            sr.Message = "Type added successfully.";
            sr.Data = newType;

            return sr;
        }

        public async Task<ServiceResponse<Models.Type>> Update(int Id,UpsertTypeDto data)
        {
            ServiceResponse<Models.Type> sr = new();

            Models.Type? existingType = await db.Types.FindAsync(Id);


            if (existingType == null)
            {
                sr.Success = false;
                sr.Message = "Type not found.";
                return sr;
            }

            bool titleExists = await db.Types.AnyAsync(c => c.Id != Id && c.Title.ToLower() == data.Title.ToLower());
            if (titleExists)
            {
                sr.Success = false;
                sr.Message = "Type with this title already exists.";
                return sr;
            }

            existingType = mapper.Map(data,existingType);


            db.Types.Update(existingType);
            await db.SaveChangesAsync();

            sr.Success = true;
            sr.Message = "Type updated successfully.";
            sr.Data = existingType;

            return sr;
        }

        public async Task<ServiceResponse<bool>> Delete(int Id)
        {
            ServiceResponse<bool> sr = new();

            Models.Type? existingType = await db.Types.FindAsync(Id);

            if (existingType == null)
            {
                sr.Success = false;
                sr.Message = "Type not found.";
                sr.Data = false;
                return sr;
            }

            db.Types.Remove(existingType);
            await db.SaveChangesAsync();

            sr.Success = true;
            sr.Message = "Type deleted successfully.";
            sr.Data = true;

            return sr;
        }

        public async Task<ServiceResponse<List<Models.Type>>> GetAll()
        {
            ServiceResponse<List<Models.Type>> sr = new();

            var types = await db.Types.ToListAsync();

            sr.Success = true;
            sr.Message = "Types fetched successfully.";
            sr.Data = types;

            return sr;
        }

        public async Task<ServiceResponse<Models.Type>> GetById(int Id)
        {
            ServiceResponse<Models.Type> sr = new();

            Models.Type? type = await db.Types.FindAsync(Id);

            if (type == null)
            {
                sr.Success = false;
                sr.Message = "Type not found.";
                return sr;
            }

            sr.Success = true;
            sr.Message = "Type retrieved successfully.";
            sr.Data = type;

            return sr;
        }


    }
}
