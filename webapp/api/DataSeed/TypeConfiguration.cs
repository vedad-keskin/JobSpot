using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.DataSeed
{
    public class TypeConfiguration: IEntityTypeConfiguration<Models.Type>
    {
        public void Configure(EntityTypeBuilder<Models.Type> builder)
        {
            builder.HasData(
                new Models.Type
                {
                    Id = 1,
                    Title = "Usluga",
                },
                new Models.Type
                {
                    Id = 2,
                    Title = "Oglas",
                }
            );
        }
    }
}