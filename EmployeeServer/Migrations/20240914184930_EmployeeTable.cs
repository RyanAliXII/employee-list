using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeServer.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GivenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MIDNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhilHealthNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Email",
                table: "Employee",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_MIDNumber",
                table: "Employee",
                column: "MIDNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_MobileNumber",
                table: "Employee",
                column: "MobileNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PhilHealthNumber",
                table: "Employee",
                column: "PhilHealthNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SSNumber",
                table: "Employee",
                column: "SSNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_TIN",
                table: "Employee",
                column: "TIN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
