using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatigaEmt7an.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_Category",
                table: "Students",
                column: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_Category",
                table: "Students");
        }
    }
}
