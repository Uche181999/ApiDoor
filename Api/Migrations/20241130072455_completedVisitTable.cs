using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class completedVisitTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ExitTime",
                table: "Visits",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "first-user-id",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b84f627d-77bc-40b2-ba83-339fa1220a19", "uche181999@gmail.com", "AQAAAAIAAYagAAAAEAANPMMKRh7ngBLu0IERhEHKNox4LHf3lI0UE41k24x1/Hzq5A5YmwLUuv6c5pc/Iw==", "9413d501-ea22-411f-8a3e-3c52be055da5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ExitTime",
                table: "Visits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "first-user-id",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5545353d-1a08-40fc-b5fe-896c1708e45f", "UCHE181999@gmail.com", "AQAAAAIAAYagAAAAEOETFoTbkatwcZ3U/BI/1hfZyP1iEvLAdkDt7KM8Stq5ISY4drWHBFuwisBIstHUJg==", "13ddb054-50b6-46f0-9ae4-541e36228ceb" });
        }
    }
}
