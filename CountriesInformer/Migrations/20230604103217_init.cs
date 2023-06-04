using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CountriesInformer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CapitalCity = table.Column<string>(type: "text", nullable: false),
                    OfficialLanguage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CapitalCity", "Name", "OfficialLanguage" },
                values: new object[,]
                {
                    { 1, "Astana", "Kazakhstan", "Kazakh" },
                    { 2, "Tashkent", "Uzbekistan", "Uzbek" },
                    { 3, "Tbilisi", "Georgia", "Georgian" },
                    { 4, "Kabul", "Afghanistan", "Pashto" },
                    { 5, "Tehran", "Iran", "Iranian" },
                    { 6, "Riyadh", "Saudi Arabia", "Arabic" },
                    { 7, "Islamabad", "Pakistan", "Urdu" },
                    { 8, "Algiers", "Algeria", "Arabic" },
                    { 9, "Ashgabat", "Turkmenistan", "Turkmen" },
                    { 10, "Ulaanbaatar", "Mongolia", "Mongolian" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
