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
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Postings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    isPublic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Postings_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Postings_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Postings_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Postings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "IT & Programming" },
                    { 2, "Marketing & PR" },
                    { 3, "Sales & Purchases" },
                    { 4, "Administration & Management" },
                    { 5, "Finance & Accounting" },
                    { 6, "Healthcare" },
                    { 7, "Education & Teaching" },
                    { 8, "Engineering & Technical Jobs" },
                    { 9, "Logistics & Transportation" },
                    { 10, "Services & Manual Jobs" },
                    { 11, "Tourism & Hospitality" },
                    { 12, "Law & Consulting" },
                    { 13, "Design & Creative Industries" },
                    { 14, "Labor & Physical Jobs" },
                    { 15, "Real Estate & Construction" },
                    { 16, "Human Resources & Recruitment" },
                    { 17, "Management & Leadership" },
                    { 18, "Arts & Culture" },
                    { 19, "Science & Research" },
                    { 20, "Environment & Sustainability" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Bosna i Hercegovina" },
                    { 2, "Srbija" },
                    { 3, "Hrvatska" },
                    { 4, "Crna Gora" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Usluga" },
                    { 2, "Oglas" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Sarajevo" },
                    { 2, 1, "Banja Luka" },
                    { 3, 1, "Tuzla" },
                    { 4, 1, "Zenica" },
                    { 5, 1, "Mostar" },
                    { 6, 1, "Bihać" },
                    { 7, 1, "Prijedor" },
                    { 8, 1, "Doboj" },
                    { 9, 1, "Bijeljina" },
                    { 10, 1, "Gračanica" },
                    { 11, 1, "Brčko" },
                    { 12, 1, "Travnik" },
                    { 13, 1, "Srebrenica" },
                    { 14, 1, "Cazin" },
                    { 15, 1, "Goražde" },
                    { 16, 1, "Bugojno" },
                    { 17, 1, "Trebinje" },
                    { 18, 1, "Jajce" },
                    { 19, 1, "Maglaj" },
                    { 20, 1, "Kakanj" },
                    { 21, 2, "Beograd" },
                    { 22, 2, "Subotica" },
                    { 23, 2, "Kragujevac" },
                    { 24, 2, "Niš" },
                    { 25, 2, "Novi Pazar" },
                    { 26, 3, "Zagreb" },
                    { 27, 3, "Šibenik" },
                    { 28, 3, "Split" },
                    { 29, 3, "Rijeka" },
                    { 30, 3, "Osijek" },
                    { 31, 4, "Podgorica" },
                    { 32, 4, "Ulcinj" },
                    { 33, 4, "Budva" },
                    { 34, 4, "Kotor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Postings_CategoryId",
                table: "Postings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Postings_CityId",
                table: "Postings",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Postings_TypeId",
                table: "Postings",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Postings_UserId",
                table: "Postings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Postings");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
