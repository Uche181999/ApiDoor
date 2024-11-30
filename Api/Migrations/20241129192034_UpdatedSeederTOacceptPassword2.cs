using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSeederTOacceptPassword2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "264bbca9-ff51-458b-8dbb-32d1e769f0cf", null, "User", "USER" },
                    { "331fee1f-ccd3-4d77-a0cc-34ec3fe43c70", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "264bbca9-ff51-458b-8dbb-32d1e769f0cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "331fee1f-ccd3-4d77-a0cc-34ec3fe43c70");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29992898-61e0-4e17-a392-2d8bc01c4d03", null, "User", "USER" },
                    { "d9c93a5a-3b03-458a-9037-e4f1ba4a0f93", null, "Admin", "ADMIN" }
                });
        }
    }
}
