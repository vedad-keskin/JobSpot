using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.DataSeed
{
    public class CategoryConfiguration: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Title = "Healthcare",
                },
                new Category
                {
                    Id = 2,
                    Title = "Technology",
                },
                new Category
                {
                    Id = 3,
                    Title = "Customer Service",
                }
         );
        }
    }
}
