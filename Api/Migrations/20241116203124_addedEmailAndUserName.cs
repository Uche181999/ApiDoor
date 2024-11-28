using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class addedEmailAndUserName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f29a118-066e-4c9d-b965-dba2a4330bad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7ae16da-1634-4248-b64e-c9626e168b0f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ac73c4b-6874-4a3a-b185-c5a9bf691fb4", null, "Admin", "ADMIN" },
                    { "e277fc59-1f86-4b96-b9d6-2fe45f67320f", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ac73c4b-6874-4a3a-b185-c5a9bf691fb4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e277fc59-1f86-4b96-b9d6-2fe45f67320f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8f29a118-066e-4c9d-b965-dba2a4330bad", null, "Admin", "ADMIN" },
                    { "c7ae16da-1634-4248-b64e-c9626e168b0f", null, "User", "USER" }
                });
        }
    }
}
