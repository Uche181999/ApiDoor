using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AdjustOtpTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d7aa440-7424-4a4d-ab58-ed0d19ef49b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2f7ae52-4805-4f79-979c-acf3151dc57c");

            migrationBuilder.RenameColumn(
                name: "createdTime",
                table: "Otps",
                newName: "CreatedTime");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "efcfc9f7-d3bc-4eaf-ac34-a2fa6556cd9f", null, "User", "USER" },
                    { "f2e26c2a-405e-4894-831c-910b78915691", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efcfc9f7-d3bc-4eaf-ac34-a2fa6556cd9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2e26c2a-405e-4894-831c-910b78915691");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Otps",
                newName: "createdTime");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d7aa440-7424-4a4d-ab58-ed0d19ef49b2", null, "User", "USER" },
                    { "f2f7ae52-4805-4f79-979c-acf3151dc57c", null, "Admin", "ADMIN" }
                });
        }
    }
}
