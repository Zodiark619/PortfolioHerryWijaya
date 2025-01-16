using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioHerryWijaya.Migrations
{
    /// <inheritdoc />
    public partial class usermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Gachas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "(Beginner Pack) Ines Pick Up Gacha");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Gachas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Ultimate Ines Pick Up Gacha");
        }
    }
}
