using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioHerryWijaya.Migrations
{
    /// <inheritdoc />
    public partial class project3new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Gachas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "GachaItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Ultimate Valby Surprise Box");

            migrationBuilder.UpdateData(
                table: "GachaItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Ultimate Weapon Surprise Box");

            migrationBuilder.UpdateData(
                table: "GachaItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Ultimate Reactor Surprise Box");

            migrationBuilder.InsertData(
                table: "GachaItems",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Energy Activator" });

            migrationBuilder.UpdateData(
                table: "Gachas",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "ultimatefreyna.png");

            migrationBuilder.InsertData(
                table: "Gachas",
                columns: new[] { "Id", "GachaItemPercentages", "GachaItems", "ImageUrl", "Name" },
                values: new object[] { 2, "[20,20,20,20,20]", "[\"Ultimate Weapon Surprise Box\",\"Ultimate Reactor Surprise Box\",\"Ines Surprise Box\",\"Crystallization Catalyst\",\"Energy Activator\"]", "ines.png", "Ultimate Ines Pick Up Gacha" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GachaItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Gachas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Gachas");

            migrationBuilder.UpdateData(
                table: "GachaItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Energy Activator");

            migrationBuilder.UpdateData(
                table: "GachaItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Energy Activator");

            migrationBuilder.UpdateData(
                table: "GachaItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Ultimate Weapon Surprise Box");
        }
    }
}
