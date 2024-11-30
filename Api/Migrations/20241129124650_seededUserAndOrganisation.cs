using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class seededUserAndOrganisation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "164fa93a-e367-4bc1-993e-e87268d389d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac05615c-c49e-4ab9-be5b-7ea1aa8aa0da");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "53bf5083-eb91-4096-922c-3633b78c116c", null, "User", "USER" },
                    { "bb20a152-2659-449f-bf46-0a135f6450ff", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Organisations",
                columns: new[] { "Id", "EmailDomain", "Name" },
                values: new object[] { 1, "@mycompany.com", "my company" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OrganisationId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "76d0ce59-cfd3-4226-bbd6-c23d1969e232", 0, "c219301d-4010-44ff-a621-77446e679791", "AppUser", "uche181999@gmail.com", false, "Uche", "Emmanuel", false, null, null, null, 1, "123456789", null, false, "78e36464-a7a3-4dac-8977-476b8c185e6d", false, "uche181999" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53bf5083-eb91-4096-922c-3633b78c116c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb20a152-2659-449f-bf46-0a135f6450ff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76d0ce59-cfd3-4226-bbd6-c23d1969e232");

            migrationBuilder.DeleteData(
                table: "Organisations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "164fa93a-e367-4bc1-993e-e87268d389d4", null, "User", "USER" },
                    { "ac05615c-c49e-4ab9-be5b-7ea1aa8aa0da", null, "Admin", "ADMIN" }
                });
        }
    }
}
