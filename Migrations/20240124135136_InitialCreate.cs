using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeInfo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    Department = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
