using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioHerryWijaya.Migrations
{
    /// <inheritdoc />
    public partial class project4start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Gachas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Amorpheus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amorpheus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmorpheusId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AmorpheusItem",
                columns: table => new
                {
                    AmorpheusId = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmorpheusItem", x => new { x.AmorpheusId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_AmorpheusItem_Amorpheus_AmorpheusId",
                        column: x => x.AmorpheusId,
                        principalTable: "Amorpheus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmorpheusItem_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amorpheus",
                columns: new[] { "Id", "ItemId", "Name" },
                values: new object[] { 1, "[1,2]", "083-AB" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "AmorpheusId", "Name" },
                values: new object[,]
                {
                    { 1, "[1]", "Enduring Legacy Polymer Syncytium Blueprint" },
                    { 2, "[1]", "Energy Activator Blueprint" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2025, 1, 20, 14, 14, 8, 828, DateTimeKind.Local).AddTicks(3904));

            migrationBuilder.CreateIndex(
                name: "IX_AmorpheusItem_ItemsId",
                table: "AmorpheusItem",
                column: "ItemsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmorpheusItem");

            migrationBuilder.DropTable(
                name: "Amorpheus");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Gachas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2025, 1, 16, 19, 35, 35, 104, DateTimeKind.Local).AddTicks(8015));
        }
    }
}
