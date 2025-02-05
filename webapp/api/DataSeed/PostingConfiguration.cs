using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.DataSeed
{
    public class PostingConfiguration: IEntityTypeConfiguration<Posting>
    {
        public void Configure(EntityTypeBuilder<Posting> builder)
        {
            builder.HasData(
                new Posting
                {
                    Id = 1,
                    Title = "Software Developer Needed",
                    Description = "Looking for an experienced C# developer to join our team.",
                    CategoryId = 1,
                    CityId = 1,
                    UserId = 1,
                    TypeId = 2,
                    isPublic = true
                },
                new Posting
                {
                    Id = 2,
                    Title = "Graphic Designer Wanted",
                    Description = "A creative graphic designer needed for marketing projects.",
                    CategoryId = 1,
                    CityId = 5,
                    UserId = 1,
                    TypeId = 2,
                    isPublic = true
                },
                new Posting
                {
                    Id = 3,
                    Title = "Remote Python Developer",
                    Description = "Remote job opportunity for Python and Django developer.",
                    CategoryId = 1,
                    CityId = 10,
                    UserId = 1,
                    TypeId = 2,
                    isPublic = false
                },
                new Posting
                {
                    Id = 4,
                    Title = "Data Analyst",
                    Description = "We are looking for a data analyst with experience in SQL and Power BI.",
                    CategoryId = 1,
                    CityId = 8,
                    UserId = 1,
                    TypeId = 2,
                    isPublic = true
                }
            );
        }
    }
}
