using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SD_Company.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptNo);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Budget = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectNo);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    DeptNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpNo);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DeptNo",
                        column: x => x.DeptNo,
                        principalTable: "Departments",
                        principalColumn: "DeptNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Works_on",
                columns: table => new
                {
                    EmpNo = table.Column<int>(type: "int", nullable: false),
                    ProjectNo = table.Column<int>(type: "int", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Enter_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works_on", x => new { x.EmpNo, x.ProjectNo });
                    table.ForeignKey(
                        name: "FK_Works_on_Employees_EmpNo",
                        column: x => x.EmpNo,
                        principalTable: "Employees",
                        principalColumn: "EmpNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Works_on_Projects_ProjectNo",
                        column: x => x.ProjectNo,
                        principalTable: "Projects",
                        principalColumn: "ProjectNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DeptNo",
                table: "Employees",
                column: "DeptNo");

            migrationBuilder.CreateIndex(
                name: "IX_Works_on_ProjectNo",
                table: "Works_on",
                column: "ProjectNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Works_on");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
