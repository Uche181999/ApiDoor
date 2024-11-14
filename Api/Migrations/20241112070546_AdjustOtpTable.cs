using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AdjustOtpTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "312a2def-409b-4fdf-8823-3c2bedb6d357");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7e66015-e4dd-46dd-8d2a-be1b115a2010");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Otps",
                newName: "IsUsed");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationId",
                table: "Otps",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d7aa440-7424-4a4d-ab58-ed0d19ef49b2", null, "User", "USER" },
                    { "f2f7ae52-4805-4f79-979c-acf3151dc57c", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IsUsed",
                table: "Otps",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationId",
                table: "Otps",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "312a2def-409b-4fdf-8823-3c2bedb6d357", null, "Admin", "ADMIN" },
                    { "b7e66015-e4dd-46dd-8d2a-be1b115a2010", null, "User", "USER" }
                });
        }
    }
}
