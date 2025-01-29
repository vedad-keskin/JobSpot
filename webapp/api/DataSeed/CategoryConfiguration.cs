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
                   Title = "IT & Software Development",
               },
                new Category
                {
                    Id = 2,
                    Title = "Healthcare & Medicine",
                },
                new Category
                {
                    Id = 3,
                    Title = "Engineering & Architecture",
                },
                new Category
                {
                    Id = 4,
                    Title = "Education & Training",
                },
                new Category
                {
                    Id = 5,
                    Title = "Sales & Marketing",
                },
                new Category
                {
                    Id = 6,
                    Title = "Customer Service",
                },
                new Category
                {
                    Id = 7,
                    Title = "Accounting & Finance",
                },
                new Category
                {
                    Id = 8,
                    Title = "Human Resources",
                },
                new Category
                {
                    Id = 9,
                    Title = "Construction & Skilled Trades",
                },
                new Category
                {
                    Id = 10,
                    Title = "Transport & Logistics",
                },
                new Category
                {
                    Id = 11,
                    Title = "Hospitality & Tourism",
                },
                new Category
                {
                    Id = 12,
                    Title = "Media & Communications",
                },
                new Category
                {
                    Id = 13,
                    Title = "Arts & Design",
                },
                new Category
                {
                    Id = 14,
                    Title = "Legal & Compliance",
                },
                new Category
                {
                    Id = 15,
                    Title = "Retail & E-commerce",
                },
                new Category
                {
                    Id = 16,
                    Title = "Manufacturing & Production",
                },
                new Category
                {
                    Id = 17,
                    Title = "Science & Research",
                },
                new Category
                {
                    Id = 18,
                    Title = "Public Sector & Government",
                },
                new Category
                {
                    Id = 19,
                    Title = "Environmental & Agriculture",
                },
                new Category
                {
                    Id = 20,
                    Title = "Freelancing & Remote Work",
                }

         );
        }
    }
}
