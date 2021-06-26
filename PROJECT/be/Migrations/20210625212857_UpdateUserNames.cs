using Microsoft.EntityFrameworkCore.Migrations;

namespace mas_project.Migrations
{
    public partial class UpdateUserNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "UserName" },
                values: new object[] { "bob.doe@example.com", "Bob", "bob" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "UserName" },
                values: new object[] { "alice.doe@example.com", "Alice", "alice" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "UserName" },
                values: new object[] { "john.doe@example.com", "John", "jDoe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "UserName" },
                values: new object[] { "jane.doe@example.com", "Jane", "janeDoe" });
        }
    }
}
