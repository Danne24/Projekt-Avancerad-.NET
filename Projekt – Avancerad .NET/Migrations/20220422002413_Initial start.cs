using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt___Avancerad_.NET.Migrations
{
    public partial class Initialstart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeFirstName = table.Column<string>(nullable: true),
                    EmployeeLastName = table.Column<string>(nullable: true),
                    EmployeeGender = table.Column<string>(nullable: true),
                    EmployeeAge = table.Column<int>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimReports",
                columns: table => new
                {
                    TimReportID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimReportWeek = table.Column<int>(nullable: false),
                    TimReportWorkingHours = table.Column<double>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimReports", x => x.TimReportID);
                    table.ForeignKey(
                        name: "FK_TimReports_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "ProjectName" },
                values: new object[] { 1, "Software project" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "ProjectName" },
                values: new object[] { 2, "Movie project" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "ProjectName" },
                values: new object[] { 3, "Video game project" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "EmployeeAge", "EmployeeFirstName", "EmployeeGender", "EmployeeLastName", "ProjectID" },
                values: new object[,]
                {
                    { 2, 35, "Anas", "Male", "Q", 1 },
                    { 3, 37, "Tobias", "Male", "Q", 1 },
                    { 1, 25, "Daniel", "Male", "Gyrén", 2 },
                    { 5, 40, "Rebecca", "Female", "Anderson", 2 },
                    { 6, 30, "Sofia", "Female", "Eriksson", 2 },
                    { 4, 60, "Reidar", "Male", "R", 3 }
                });

            migrationBuilder.InsertData(
                table: "TimReports",
                columns: new[] { "TimReportID", "EmployeeID", "TimReportWeek", "TimReportWorkingHours" },
                values: new object[,]
                {
                    { 2, 2, 1, 25.0 },
                    { 3, 3, 1, 25.0 },
                    { 1, 1, 1, 35.0 },
                    { 5, 5, 1, 25.0 },
                    { 6, 6, 1, 30.0 },
                    { 4, 4, 1, 40.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectID",
                table: "Employees",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_TimReports_EmployeeID",
                table: "TimReports",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimReports");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
