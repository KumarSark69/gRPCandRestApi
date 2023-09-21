using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeGRPC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeList",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeList", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmployeeList",
                columns: new[] { "Id", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { 1L, "makarapura", "abc@gmail.com", "Abc" },
                    { 2L, "bustand", "xyz@gmail.com", "xyz" },
                    { 3L, "changa", "ram@gmail.com", "ram" },
                    { 4L, "changa", "shyam@gmail.com", "shyam" },
                    { 5L, "Testpura", "test@gmail.com", "Test" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeList");
        }
    }
}
