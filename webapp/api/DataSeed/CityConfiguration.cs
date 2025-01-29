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
                    Title = "Banja Luka",
                },
                new City
                {
                    Id = 2,
                    Title = "Sarajevo",
                },
                new City
                {
                    Id = 3,
                    Title = "Mostar",
                },
                new City
                {
                    Id = 4,
                    Title = "Tuzla",
                },
                new City
                {
                    Id = 5,
                    Title = "Zenica",
                },
                new City
                {
                    Id = 6,
                    Title = "Doboj",
                },
                new City
                {
                    Id = 7,
                    Title = "Bijeljina",
                },
                new City
                {
                    Id = 8,
                    Title = "Trebinje",
                },
                new City
                {
                    Id = 9,
                    Title = "Prijedor",
                },
                new City
                {
                    Id = 10,
                    Title = "Gradiška",
                },
                new City
                {
                    Id = 11,
                    Title = "Brčko",
                },
                new City
                {
                    Id = 12,
                    Title = "Široki Brijeg",
                },
                new City
                {
                    Id = 13,
                    Title = "Livno",
                },
                new City
                {
                    Id = 14,
                    Title = "Konjic",
                },
                new City
                {
                    Id = 15,
                    Title = "Jajce",
                },
                new City
                {
                    Id = 16,
                    Title = "Zvornik",
                },
                new City
                {
                    Id = 17,
                    Title = "Cazin",
                },
                new City
                {
                    Id = 18,
                    Title = "Bihać",
                },
                new City
                {
                    Id = 19,
                    Title = "Travnik",
                },
                new City
                {
                    Id = 20,
                    Title = "Bugojno",
                },
                new City
                {
                    Id = 21,
                    Title = "Goražde",
                },
                new City
                {
                    Id = 22,
                    Title = "Foča",
                },
                new City
                {
                    Id = 23,
                    Title = "Srebrenica",
                },
                new City
                {
                    Id = 24,
                    Title = "Višegrad",
                },
                new City
                {
                    Id = 25,
                    Title = "Laktaši",
                },
                new City
                {
                    Id = 26,
                    Title = "Nevesinje",
                },
                new City
                {
                    Id = 27,
                    Title = "Sanski Most",
                },
                new City
                {
                    Id = 28,
                    Title = "Bosanska Krupa",
                },
                new City
                {
                    Id = 29,
                    Title = "Kotor Varoš",
                },
                new City
                {
                    Id = 30,
                    Title = "Modriča",
                }

         );
        }
    }
}
