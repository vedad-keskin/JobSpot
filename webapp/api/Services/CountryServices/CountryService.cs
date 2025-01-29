using api.DTOs.Country;
using api.Models;
using AutoMapper;

namespace api.Services.UserServices
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



            Country newCountry = mapper.Map<Country>(data);

            db.Countries.Add(newCountry);
            await db.SaveChangesAsync();

            sr.Success = true;
            sr.Message = "Country added succesfully!";
            sr.Data = newCountry;

            return sr;
        }
    }
}

