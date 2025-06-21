using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatigaEmt7an.Api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Governorates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReligionEdu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NationalEdu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EconomicsStatistics = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutCourses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolAdministrations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernorateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolAdministrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolAdministrations_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolAdministrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GovernorateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schools_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schools_SchoolAdministrations_SchoolAdministrationId",
                        column: x => x.SchoolAdministrationId,
                        principalTable: "SchoolAdministrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    TotalGrades = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GovernorateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolAdministrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_SchoolAdministrations_SchoolAdministrationId",
                        column: x => x.SchoolAdministrationId,
                        principalTable: "SchoolAdministrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentGrades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Foreign1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Foreign2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Math1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Math2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    History = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Geography = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Philosophy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Psychology = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Chemistry = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Biology = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Geology = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Physics = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutCoursesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentGrades_OutCourses_OutCoursesId",
                        column: x => x.OutCoursesId,
                        principalTable: "OutCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentGrades_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolAdministrations_GovernorateId",
                table: "SchoolAdministrations",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_GovernorateId",
                table: "Schools",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_SchoolAdministrationId",
                table: "Schools",
                column: "SchoolAdministrationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrades_OutCoursesId",
                table: "StudentGrades",
                column: "OutCoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrades_StudentId",
                table: "StudentGrades",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_GovernorateId",
                table: "Students",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolAdministrationId",
                table: "Students",
                column: "SchoolAdministrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolId",
                table: "Students",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SeatNumber",
                table: "Students",
                column: "SeatNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentGrades");

            migrationBuilder.DropTable(
                name: "OutCourses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "SchoolAdministrations");

            migrationBuilder.DropTable(
                name: "Governorates");
        }
    }
}
