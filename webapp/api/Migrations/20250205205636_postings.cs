using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class postings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Postings",
                columns: new[] { "Id", "CategoryId", "CityId", "Description", "Title", "TypeId", "UserId", "isPublic" },
                values: new object[,]
                {
                    { 1, 1, 1, "Looking for an experienced C# developer to join our team.", "Software Developer Needed", 2, 1, true },
                    { 2, 1, 5, "A creative graphic designer needed for marketing projects.", "Graphic Designer Wanted", 2, 1, true },
                    { 3, 1, 10, "Remote job opportunity for Python and Django developer.", "Remote Python Developer", 2, 1, false },
                    { 4, 1, 8, "We are looking for a data analyst with experience in SQL and Power BI.", "Data Analyst", 2, 1, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Postings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Postings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Postings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Postings",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
