using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.DataSeed
{
    public class CountryConfiguration: IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country
                {
                    Id = 1,
                    Title = "Bosna i Hercegovina",
                },
                new Country
                {
                    Id = 2,
                    Title = "Srbija",
                },
                new Country
                {
                    Id = 3,
                    Title = "Hrvatska",
                },
                new Country
                {
                    Id = 4,
                    Title = "Crna Gora",
                }
            );
        }
    }
}
