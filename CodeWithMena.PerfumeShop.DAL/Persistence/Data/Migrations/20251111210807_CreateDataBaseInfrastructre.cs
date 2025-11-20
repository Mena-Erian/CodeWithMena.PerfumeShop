using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDataBaseInfrastructre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PerfumeOils",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvailableQuantityPerGram = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDate()"),
                    LastModifiedBy = table.Column<string>(type: "varchar(50)", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, computedColumnSql: "GETUTCDate()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FragranceType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FragranceFamily = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RatingOfSale = table.Column<int>(type: "int", nullable: false),
                    SupplierPrice = table.Column<decimal>(type: "decimal(10,3)", precision: 10, scale: 3, nullable: true),
                    SalePrice = table.Column<decimal>(type: "decimal(10,3)", precision: 10, scale: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfumeOils", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerfumeOils_Name",
                table: "PerfumeOils",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfumeOils");
        }
    }
}
