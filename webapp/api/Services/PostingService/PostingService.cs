using api.DTOs.Posting;
using api.Models;
using api.Services.UserServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services.PostingService
{
    public class PostingService: IPostingService
    {

        private readonly DBContext db;
        private readonly IMapper mapper;


        public PostingService(DBContext _db,IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;

        }

        public async Task<ServiceResponse<Posting>> Insert(UpsertPostingDto data)
        {
            ServiceResponse<Posting> sr = new();

            Posting newPosting = mapper.Map<Posting>(data);

            db.Postings.Add(newPosting);
            await db.SaveChangesAsync();

            sr.Success = true;
            sr.Message = "Posting added successfully.";
            sr.Data = newPosting;

            return sr;
        }


        public async Task<ServiceResponse<Posting>> Update(int Id,UpsertPostingDto data)
        {
            ServiceResponse<Posting> sr = new();

            Posting? existingPosting = await db.Postings.FindAsync(Id);

            if (existingPosting == null)
            {
                sr.Success = false;
                sr.Message = "Posting not found.";
                return sr;
            }

            existingPosting = mapper.Map(data,existingPosting);

            db.Postings.Update(existingPosting);
            await db.SaveChangesAsync();

            sr.Success = true;
            sr.Message = "Posting updated successfully.";
            sr.Data = existingPosting;

            return sr;
        }


        public async Task<ServiceResponse<bool>> Delete(int Id)
        {
            ServiceResponse<bool> sr = new();

            Posting? existingPosting = await db.Postings.FindAsync(Id);

            if (existingPosting == null)
            {
                sr.Success = false;
                sr.Message = "Posting not found.";
                sr.Data = false;
                return sr;
            }

            db.Postings.Remove(existingPosting);
            await db.SaveChangesAsync();

            sr.Success = true;
            sr.Message = "Posting deleted successfully.";
            sr.Data = true;

            return sr;
        }


        public async Task<ServiceResponse<List<Posting>>> GetAll()
        {
            ServiceResponse<List<Posting>> sr = new();


            var postings = await db.Postings
                .Include(x => x.Category)
                .Include(x => x.User)
                .Include(x => x.Type)
                .Include(x => x.City)
                .ToListAsync();

            sr.Success = true;
            sr.Message = "Postings fetched successfully.";
            sr.Data = postings;

            return sr;
        }


        public async Task<ServiceResponse<Posting>> GetById(int Id)
        {
            ServiceResponse<Posting> sr = new();

            Posting? posting = await db.Postings.FindAsync(Id);

            if (posting == null)
            {
                sr.Success = false;
                sr.Message = "Posting not found.";
                return sr;
            }

            sr.Success = true;
            sr.Message = "Posting retrieved successfully.";
            sr.Data = posting;

            return sr;
        }
    }
}
