using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class thirdUdateonDatabaseseeding3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "first-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5545353d-1a08-40fc-b5fe-896c1708e45f", "AQAAAAIAAYagAAAAEOETFoTbkatwcZ3U/BI/1hfZyP1iEvLAdkDt7KM8Stq5ISY4drWHBFuwisBIstHUJg==", "13ddb054-50b6-46f0-9ae4-541e36228ceb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "first-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8587fe6-81b9-4515-8171-07498dd9eb2f", "AQAAAAIAAYagAAAAEPAnNRWkd/m1oY0g0JyFGyznUR2S1fU/pk9nK6/+vQ6HjZKZf5IqGHWlBIYRcC+U+w==", "bc6be400-fb34-4317-bafc-afd9345f7cd8" });
        }
    }
}
