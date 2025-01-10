using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioHerryWijaya.Migrations
{
    /// <inheritdoc />
    public partial class project3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GachaItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GachaItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gachas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GachaItems = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GachaItemPercentages = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gachas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GachaItems",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "1 Million Gold" },
                    { 2, "1 Million Kuiper" },
                    { 3, "Ultimate Freyna Surprise Box" },
                    { 4, "Crystallization Catalyst" },
                    { 5, "Energy Activator" },
                    { 7, "Energy Activator" },
                    { 8, "Ultimate Weapon Surprise Box" }
                });

            migrationBuilder.InsertData(
                table: "Gachas",
                columns: new[] { "Id", "GachaItemPercentages", "GachaItems", "Name" },
                values: new object[] { 1, "[30,30,10,15,15]", "[\"1 Million Gold\",\"1 Million Kuiper\",\"Ultimate Freyna Surprise Box\",\"Crystallization Catalyst\",\"Energy Activator\"]", "Ultimate Freyna Pick Up Gacha" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GachaItems");

            migrationBuilder.DropTable(
                name: "Gachas");
        }
    }
}
