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
                    Title = "Tuzla",
                },
                new City
                {
                    Id = 4,
                    Title = "Zenica",
                },
                new City
                {
                    Id = 5,
                    Title = "Mostar",
                }
         );
        }
    }
}
