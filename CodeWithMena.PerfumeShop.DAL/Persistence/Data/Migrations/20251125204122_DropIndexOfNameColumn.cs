using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class DropIndexOfNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PerfumeOils_Name",
                table: "PerfumeOils");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PerfumeOils_Name",
                table: "PerfumeOils",
                column: "Name",
                unique: true);
        }
    }
}
