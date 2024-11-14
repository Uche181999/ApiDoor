using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AdjustOtpTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "CreatedAt");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b761551-303f-4f66-93ab-fec7bb4b4f0d", null, "Admin", "ADMIN" },
                    { "85de7e28-4308-48ac-8936-0bc8a755ca1b", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b761551-303f-4f66-93ab-fec7bb4b4f0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85de7e28-4308-48ac-8936-0bc8a755ca1b");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
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
    }
}
