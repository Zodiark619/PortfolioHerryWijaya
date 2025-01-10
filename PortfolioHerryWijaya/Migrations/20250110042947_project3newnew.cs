using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioHerryWijaya.Migrations
{
    /// <inheritdoc />
    public partial class project3newnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Gachas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Gachas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "10% chance to get Ultimate Freyna Surprise Box (Contains unique cosmetics, taunts, skins, and animations for Ultimate Freyna)");

            migrationBuilder.UpdateData(
                table: "Gachas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "20% chance to get Ines Surprise Box (Contains Ines fragments and 1% chance of obtaining Ines's unique skin)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Gachas");
        }
    }
}
