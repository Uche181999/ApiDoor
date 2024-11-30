using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class thirdUdateonDatabaseseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "first-role-id", null, "User", "USER" },
                    { "sec-role-id", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OrganisationId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "first-user-id", 0, "5469a3ad-fce1-4b64-9358-5f6233a5a6ac", "AppUser", "UCHE181999@gmail.com", true, null, null, false, null, "UCHE181999@GMAIL.COM", "UCHE18999", 1, "AQAAAAIAAYagAAAAECiH9t1b77/LQwQ1nx2Ku+rjJ/S/9wusvVMb+5jS0zW04nogIAEAFja+Qy20R5+wlg==", null, false, "e777acb1-1e52-4339-b9e8-69e05dd1d7e3", false, "uche181999" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "first-role-id", "first-user-id" },
                    { "sec-role-id", "first-user-id" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "first-role-id", "first-user-id" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "sec-role-id", "first-user-id" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "first-role-id");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "sec-role-id");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "first-user-id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e654e93-fc69-45ef-8c6a-c8e4891b82de", null, "User", "USER" },
                    { "bf672e6b-da2f-4fcf-9101-1d4f2352bc35", null, "Admin", "ADMIN" }
                });
        }
    }
}
