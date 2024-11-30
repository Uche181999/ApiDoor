using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class thirdUdateonDatabaseseeding2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "first-user-id",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8587fe6-81b9-4515-8171-07498dd9eb2f", "Uche", "Emmanuel", "AQAAAAIAAYagAAAAEPAnNRWkd/m1oY0g0JyFGyznUR2S1fU/pk9nK6/+vQ6HjZKZf5IqGHWlBIYRcC+U+w==", "bc6be400-fb34-4317-bafc-afd9345f7cd8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "first-user-id",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5469a3ad-fce1-4b64-9358-5f6233a5a6ac", null, null, "AQAAAAIAAYagAAAAECiH9t1b77/LQwQ1nx2Ku+rjJ/S/9wusvVMb+5jS0zW04nogIAEAFja+Qy20R5+wlg==", "e777acb1-1e52-4339-b9e8-69e05dd1d7e3" });
        }
    }
}
