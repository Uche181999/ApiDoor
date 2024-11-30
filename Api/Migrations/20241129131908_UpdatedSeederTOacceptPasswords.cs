using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSeederTOacceptPasswords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65a8bfab-0e30-420b-a33e-bdf6f67372d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b87d8903-2394-495d-857b-d3b4cf64f254");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29992898-61e0-4e17-a392-2d8bc01c4d03", null, "User", "USER" },
                    { "d9c93a5a-3b03-458a-9037-e4f1ba4a0f93", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29992898-61e0-4e17-a392-2d8bc01c4d03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9c93a5a-3b03-458a-9037-e4f1ba4a0f93");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "65a8bfab-0e30-420b-a33e-bdf6f67372d5", null, "User", "USER" },
                    { "b87d8903-2394-495d-857b-d3b4cf64f254", null, "Admin", "ADMIN" }
                });
        }
    }
}
