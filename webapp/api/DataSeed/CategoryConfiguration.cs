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
                    Title = "IT & Programming",
                },
                new Category
                {
                    Id = 2,
                    Title = "Marketing & PR",
                },
                new Category
                {
                    Id = 3,
                    Title = "Sales & Purchases",
                },
                new Category
                {
                    Id = 4,
                    Title = "Administration & Management",
                },
                new Category
                {
                    Id = 5,
                    Title = "Finance & Accounting",
                },
                new Category
                {
                    Id = 6,
                    Title = "Healthcare",
                },
                new Category
                {
                    Id = 7,
                    Title = "Education & Teaching",
                },
                new Category
                {
                    Id = 8,
                    Title = "Engineering & Technical Jobs",
                },
                new Category
                {
                    Id = 9,
                    Title = "Logistics & Transportation",
                },
                new Category
                {
                    Id = 10,
                    Title = "Services & Manual Jobs",
                },
                new Category
                {
                    Id = 11,
                    Title = "Tourism & Hospitality",
                },
                new Category
                {
                    Id = 12,
                    Title = "Law & Consulting",
                },
                new Category
                {
                    Id = 13,
                    Title = "Design & Creative Industries",
                },
                new Category
                {
                    Id = 14,
                    Title = "Labor & Physical Jobs",
                },
                new Category
                {
                    Id = 15,
                    Title = "Real Estate & Construction",
                },
                new Category
                {
                    Id = 16,
                    Title = "Human Resources & Recruitment",
                },
                new Category
                {
                    Id = 17,
                    Title = "Management & Leadership",
                },
                new Category
                {
                    Id = 18,
                    Title = "Arts & Culture",
                },
                new Category
                {
                    Id = 19,
                    Title = "Science & Research",
                },
                new Category
                {
                    Id = 20,
                    Title = "Environment & Sustainability",
                }
         );
        }
    }
}
