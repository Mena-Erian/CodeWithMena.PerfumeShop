using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProvidersColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManufacturingCompany",
                table: "PerfumeOils",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "PerfumeOils",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManufacturingCompany",
                table: "PerfumeOils");

            migrationBuilder.DropColumn(
                name: "SupplierName",
                table: "PerfumeOils");
        }
    }
}
