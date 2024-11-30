using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSeederTOacceptPassword3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "5e654e93-fc69-45ef-8c6a-c8e4891b82de", null, "User", "USER" },
                    { "bf672e6b-da2f-4fcf-9101-1d4f2352bc35", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e654e93-fc69-45ef-8c6a-c8e4891b82de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf672e6b-da2f-4fcf-9101-1d4f2352bc35");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "264bbca9-ff51-458b-8dbb-32d1e769f0cf", null, "User", "USER" },
                    { "331fee1f-ccd3-4d77-a0cc-34ec3fe43c70", null, "Admin", "ADMIN" }
                });
        }
    }
}
