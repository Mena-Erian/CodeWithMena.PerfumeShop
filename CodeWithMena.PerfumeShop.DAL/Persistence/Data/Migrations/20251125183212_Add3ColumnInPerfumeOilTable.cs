using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add3ColumnInPerfumeOilTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlternativeName",
                table: "PerfumeOils",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "PerfumeOils",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FashionHouse",
                table: "PerfumeOils",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlternativeName",
                table: "PerfumeOils");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "PerfumeOils");

            migrationBuilder.DropColumn(
                name: "FashionHouse",
                table: "PerfumeOils");
        }
    }
}
