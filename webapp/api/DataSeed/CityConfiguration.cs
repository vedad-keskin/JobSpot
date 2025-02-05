using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.DataSeed
{
    public class CityConfiguration: IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(
                new City
                {
                    Id = 1,
                    Title = "Sarajevo",
                    CountryId = 1,
                },
                new City
                {
                    Id = 2,
                    Title = "Banja Luka",
                    CountryId = 1,

                },
                new City
                {
                    Id = 3,
                    Title = "Tuzla",
                    CountryId = 1,

                },
                new City
                {
                    Id = 4,
                    Title = "Zenica",
                    CountryId = 1,

                },
                new City
                {
                    Id = 5,
                    Title = "Mostar",
                    CountryId = 1,

                },
                new City
                {
                    Id = 6,
                    Title = "Bihać",
                    CountryId = 1,

                },
                new City
                {
                    Id = 7,
                    Title = "Prijedor",
                    CountryId = 1,

                },
                new City
                {
                    Id = 8,
                    Title = "Doboj",
                    CountryId = 1,

                },
                new City
                {
                    Id = 9,
                    Title = "Bijeljina",
                    CountryId = 1,

                },
                new City
                {
                    Id = 10,
                    Title = "Gračanica",
                    CountryId = 1,

                },
                new City
                {
                    Id = 11,
                    Title = "Brčko",
                    CountryId = 1,

                },
                new City
                {
                    Id = 12,
                    Title = "Travnik",
                    CountryId = 1,

                },
                new City
                {
                    Id = 13,
                    Title = "Srebrenica",
                    CountryId = 1,

                },
                new City
                {
                    Id = 14,
                    Title = "Cazin",
                    CountryId = 1,

                },
                new City
                {
                    Id = 15,
                    Title = "Goražde",
                    CountryId = 1,

                },
                new City
                {
                    Id = 16,
                    Title = "Bugojno",
                    CountryId = 1,

                },
                new City
                {
                    Id = 17,
                    Title = "Trebinje",
                    CountryId = 1,

                },
                new City
                {
                    Id = 18,
                    Title = "Jajce",
                    CountryId = 1,

                },
                new City
                {
                    Id = 19,
                    Title = "Maglaj",
                    CountryId = 1,

                },
                new City
                {
                    Id = 20,
                    Title = "Kakanj",
                    CountryId = 1,

                },
                 new City
                 {
                     Id = 21,
                     Title = "Beograd",
                     CountryId = 2,
                 },
                 new City
                 {
                     Id = 22,
                     Title = "Subotica",
                     CountryId = 2,
                 },
                 new City
                 {
                     Id = 23,
                     Title = "Kragujevac",
                     CountryId = 2,
                 },
                 new City
                 {
                     Id = 24,
                     Title = "Niš",
                     CountryId = 2,
                 },
                 new City
                 {
                     Id = 25,
                     Title = "Novi Pazar",
                     CountryId = 2,
                 },
                 new City
                 {
                     Id = 26,
                     Title = "Zagreb",
                     CountryId = 3,
                 },
                 new City
                 {
                     Id = 27,
                     Title = "Šibenik",
                     CountryId = 3,
                 },
                 new City
                 {
                     Id = 28,
                     Title = "Split",
                     CountryId = 3,
                 },
                 new City
                 {
                     Id = 29,
                     Title = "Rijeka",
                     CountryId = 3,
                 },
                 new City
                 {
                     Id = 30,
                     Title = "Osijek",
                     CountryId = 3,
                 },
                 new City
                 {
                     Id = 31,
                     Title = "Podgorica",
                     CountryId = 4,
                 },
                  new City
                  {
                      Id = 32,
                      Title = "Ulcinj",
                      CountryId = 4,
                  },
                   new City
                   {
                       Id = 33,
                       Title = "Budva",
                       CountryId = 4,
                   },
                    new City
                    {
                        Id = 34,
                        Title = "Kotor",
                        CountryId = 4,
                    }
         );
        }
    }
}
