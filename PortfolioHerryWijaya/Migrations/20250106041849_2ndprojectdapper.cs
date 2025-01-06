using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioHerryWijaya.Migrations
{
    /// <inheritdoc />
    public partial class _2ndprojectdapper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DaysGoneWeapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysGoneWeapons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DaysGoneWeapons",
                columns: new[] { "Id", "Condition", "Name", "Source", "Type" },
                values: new object[,]
                {
                    { 1, 1, "SAF", "Pick Up", "Assault Rifle" },
                    { 2, 3, "MWS", "Hot Springs", "Assault Rifle" },
                    { 3, 3, "US556", "Hot Springs", "Assault Rifle" },
                    { 4, 1, "M7", "Pick Up", "Rifle" },
                    { 5, 2, ".22 Repeater", "Hot Springs", "Rifle" },
                    { 6, 5, "Liberator", "Iron Mike's", "Shotgun" },
                    { 7, 4, "PPSH-41", "Wizard Island", "SMG" },
                    { 8, 3, "SWAT-10", "Iron Mike's", "SMG" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaysGoneWeapons");
        }
    }
}
