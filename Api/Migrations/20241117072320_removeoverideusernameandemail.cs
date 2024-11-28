using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class removeoverideusernameandemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "0407ee25-b2c3-43f9-bf92-cdccd490ff13", null, "User", "USER" },
                    { "951197d8-86e4-4a9a-96d2-252d266c91ad", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0407ee25-b2c3-43f9-bf92-cdccd490ff13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "951197d8-86e4-4a9a-96d2-252d266c91ad");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ac73c4b-6874-4a3a-b185-c5a9bf691fb4", null, "Admin", "ADMIN" },
                    { "e277fc59-1f86-4b96-b9d6-2fe45f67320f", null, "User", "USER" }
                });
        }
    }
}
