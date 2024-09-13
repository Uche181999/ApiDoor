using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddNornalizedName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "287ab796-9b91-4a42-bd7f-1cf4afd1cb5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f358bdf8-9800-4d2e-9dd5-2132d15f942b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3df7f023-7965-4fbe-8526-ef8cc1d621f5", null, "User", "USER" },
                    { "97ac5b29-e972-4e17-889e-796d9fd67723", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3df7f023-7965-4fbe-8526-ef8cc1d621f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97ac5b29-e972-4e17-889e-796d9fd67723");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "287ab796-9b91-4a42-bd7f-1cf4afd1cb5f", null, "User", null },
                    { "f358bdf8-9800-4d2e-9dd5-2132d15f942b", null, "Admin", null }
                });
        }
    }
}
