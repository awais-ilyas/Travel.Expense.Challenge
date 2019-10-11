using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelExpenseChallenge.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Designation = table.Column<string>(maxLength: 30, nullable: true),
                    SupervisorId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    SubmittedDate = table.Column<DateTime>(nullable: false),
                    ApprovedById = table.Column<int>(nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelExpenses_Employees_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TravelExpenses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Designation", "Email", "FirstName", "IsActive", "LastName", "PhoneNumber", "SupervisorId" },
                values: new object[,]
                {
                    { 1, "Software Engineer", "awais.i@outlook.com", "Awais", true, "Ilyas", "+971528565160", 3 },
                    { 2, "IT Engineer", "jklein@domain.com", "Jonas", true, "Klein", "+12546987120", 4 },
                    { 3, "Team Leader", "jsmith@domain.com", "John", true, "Smith", null, null },
                    { 4, "Team Leader", "jdoe@domain.com", "John", true, "Doe", null, null },
                    { 5, "Finance Manager", "karnold@domain.com", "Kevin", true, "Arnold", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelExpenses_ApprovedById",
                table: "TravelExpenses",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_TravelExpenses_EmployeeId",
                table: "TravelExpenses",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelExpenses");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
