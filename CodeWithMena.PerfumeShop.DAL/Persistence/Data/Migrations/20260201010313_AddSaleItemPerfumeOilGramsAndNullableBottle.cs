using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSaleItemPerfumeOilGramsAndNullableBottle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "BottleId",
                table: "SaleItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<decimal>(
                name: "PerfumeOilGrams",
                table: "SaleItems",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerfumeOilGrams",
                table: "SaleItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "BottleId",
                table: "SaleItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
