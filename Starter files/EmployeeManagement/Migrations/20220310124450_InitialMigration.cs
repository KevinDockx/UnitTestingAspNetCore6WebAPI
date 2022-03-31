using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsNew = table.Column<bool>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalEmployees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Company = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalEmployees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalEmployees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    YearsInService = table.Column<int>(type: "INTEGER", nullable: false),
                    Salary = table.Column<decimal>(type: "TEXT", nullable: false),
                    MinimumRaiseGiven = table.Column<bool>(type: "INTEGER", nullable: false),
                    JobLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalEmployees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseInternalEmployee",
                columns: table => new
                {
                    AttendedCoursesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmployeesThatAttendedId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInternalEmployee", x => new { x.AttendedCoursesId, x.EmployeesThatAttendedId });
                    table.ForeignKey(
                        name: "FK_CourseInternalEmployee_Courses_AttendedCoursesId",
                        column: x => x.AttendedCoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseInternalEmployee_InternalEmployees_EmployeesThatAttendedId",
                        column: x => x.EmployeesThatAttendedId,
                        principalTable: "InternalEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "IsNew", "Title" },
                values: new object[] { new Guid("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"), false, "Respecting Your Colleagues" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "IsNew", "Title" },
                values: new object[] { new Guid("37e03ca7-c730-4351-834c-b66f280cdb01"), false, "Company Introduction" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "IsNew", "Title" },
                values: new object[] { new Guid("844e14ce-c055-49e9-9610-855669c9859b"), false, "Dealing with Customers 101" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "IsNew", "Title" },
                values: new object[] { new Guid("cbf6db3b-c4ee-46aa-9457-5fa8aefef33a"), false, "Disaster Management 101" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "IsNew", "Title" },
                values: new object[] { new Guid("d6e0e4b7-9365-4332-9b29-bb7bf09664a6"), false, "Dealing with Customers - Advanced" });

            migrationBuilder.InsertData(
                table: "ExternalEmployees",
                columns: new[] { "Id", "Company", "FirstName", "LastName" },
                values: new object[] { new Guid("72f2f5fe-e50c-4966-8420-d50258aefdcb"), "IT for Everyone, Inc", "Amanda", "Smith" });

            migrationBuilder.InsertData(
                table: "InternalEmployees",
                columns: new[] { "Id", "FirstName", "JobLevel", "LastName", "MinimumRaiseGiven", "Salary", "YearsInService" },
                values: new object[] { new Guid("72f2f5fe-e50c-4966-8420-d50258aefdcb"), "Megan", 2, "Jones", false, 3000m, 2 });

            migrationBuilder.InsertData(
                table: "InternalEmployees",
                columns: new[] { "Id", "FirstName", "JobLevel", "LastName", "MinimumRaiseGiven", "Salary", "YearsInService" },
                values: new object[] { new Guid("f484ad8f-78fd-46d1-9f87-bbb1e676e37f"), "Jaimy", 1, "Johnson", true, 3400m, 3 });

            migrationBuilder.InsertData(
                table: "CourseInternalEmployee",
                columns: new[] { "AttendedCoursesId", "EmployeesThatAttendedId" },
                values: new object[] { new Guid("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"), new Guid("72f2f5fe-e50c-4966-8420-d50258aefdcb") });

            migrationBuilder.InsertData(
                table: "CourseInternalEmployee",
                columns: new[] { "AttendedCoursesId", "EmployeesThatAttendedId" },
                values: new object[] { new Guid("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"), new Guid("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") });

            migrationBuilder.InsertData(
                table: "CourseInternalEmployee",
                columns: new[] { "AttendedCoursesId", "EmployeesThatAttendedId" },
                values: new object[] { new Guid("37e03ca7-c730-4351-834c-b66f280cdb01"), new Guid("72f2f5fe-e50c-4966-8420-d50258aefdcb") });

            migrationBuilder.InsertData(
                table: "CourseInternalEmployee",
                columns: new[] { "AttendedCoursesId", "EmployeesThatAttendedId" },
                values: new object[] { new Guid("37e03ca7-c730-4351-834c-b66f280cdb01"), new Guid("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") });

            migrationBuilder.InsertData(
                table: "CourseInternalEmployee",
                columns: new[] { "AttendedCoursesId", "EmployeesThatAttendedId" },
                values: new object[] { new Guid("844e14ce-c055-49e9-9610-855669c9859b"), new Guid("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") });

            migrationBuilder.CreateIndex(
                name: "IX_CourseInternalEmployee_EmployeesThatAttendedId",
                table: "CourseInternalEmployee",
                column: "EmployeesThatAttendedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseInternalEmployee");

            migrationBuilder.DropTable(
                name: "ExternalEmployees");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "InternalEmployees");
        }
    }
}
