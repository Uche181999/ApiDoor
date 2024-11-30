using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class completedVisitTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "first-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe2bc926-b1e9-44cb-9987-9e95cd617c30", "AQAAAAIAAYagAAAAEGs4moV43L1N0x5p7AjKXlnK/3sQjwGRmWZKlHYYggDnnlPpaELq4wBO1aSvA9LKpA==", "16d1644e-5d7a-4579-882a-cb14d27c5d9c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "first-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b84f627d-77bc-40b2-ba83-339fa1220a19", "AQAAAAIAAYagAAAAEAANPMMKRh7ngBLu0IERhEHKNox4LHf3lI0UE41k24x1/Hzq5A5YmwLUuv6c5pc/Iw==", "9413d501-ea22-411f-8a3e-3c52be055da5" });
        }
    }
}
