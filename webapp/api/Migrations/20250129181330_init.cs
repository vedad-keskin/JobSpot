using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "IT & Software Development" },
                    { 2, "Healthcare & Medicine" },
                    { 3, "Engineering & Architecture" },
                    { 4, "Education & Training" },
                    { 5, "Sales & Marketing" },
                    { 6, "Customer Service" },
                    { 7, "Accounting & Finance" },
                    { 8, "Human Resources" },
                    { 9, "Construction & Skilled Trades" },
                    { 10, "Transport & Logistics" },
                    { 11, "Hospitality & Tourism" },
                    { 12, "Media & Communications" },
                    { 13, "Arts & Design" },
                    { 14, "Legal & Compliance" },
                    { 15, "Retail & E-commerce" },
                    { 16, "Manufacturing & Production" },
                    { 17, "Science & Research" },
                    { 18, "Public Sector & Government" },
                    { 19, "Environmental & Agriculture" },
                    { 20, "Freelancing & Remote Work" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Banja Luka" },
                    { 2, "Sarajevo" },
                    { 3, "Mostar" },
                    { 4, "Tuzla" },
                    { 5, "Zenica" },
                    { 6, "Doboj" },
                    { 7, "Bijeljina" },
                    { 8, "Trebinje" },
                    { 9, "Prijedor" },
                    { 10, "Gradiška" },
                    { 11, "Brčko" },
                    { 12, "Široki Brijeg" },
                    { 13, "Livno" },
                    { 14, "Konjic" },
                    { 15, "Jajce" },
                    { 16, "Zvornik" },
                    { 17, "Cazin" },
                    { 18, "Bihać" },
                    { 19, "Travnik" },
                    { 20, "Bugojno" },
                    { 21, "Goražde" },
                    { 22, "Foča" },
                    { 23, "Srebrenica" },
                    { 24, "Višegrad" },
                    { 25, "Laktaši" },
                    { 26, "Nevesinje" },
                    { 27, "Sanski Most" },
                    { 28, "Bosanska Krupa" },
                    { 29, "Kotor Varoš" },
                    { 30, "Modriča" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "Bosna i Hercegovina" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
