using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddedColumnCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b761551-303f-4f66-93ab-fec7bb4b4f0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85de7e28-4308-48ac-8936-0bc8a755ca1b");

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Otps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8f29a118-066e-4c9d-b965-dba2a4330bad", null, "Admin", "ADMIN" },
                    { "c7ae16da-1634-4248-b64e-c9626e168b0f", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f29a118-066e-4c9d-b965-dba2a4330bad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7ae16da-1634-4248-b64e-c9626e168b0f");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Otps");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b761551-303f-4f66-93ab-fec7bb4b4f0d", null, "Admin", "ADMIN" },
                    { "85de7e28-4308-48ac-8936-0bc8a755ca1b", null, "User", "USER" }
                });
        }
    }
}
