using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatigaEmt7an.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexToTotalGrades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_TotalGrades",
                table: "Students",
                column: "TotalGrades");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_TotalGrades",
                table: "Students");
        }
    }
}
