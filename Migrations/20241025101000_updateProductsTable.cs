using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB_Shop.Migrations
{
    public partial class updateProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastSold",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumberSold",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastSold",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "NumberSold",
                table: "Product");
        }
    }
}
