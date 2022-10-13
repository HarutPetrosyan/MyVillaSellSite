using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaApi.Migrations
{
    public partial class Verjnakan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 7, 12, 30, 34, 18, DateTimeKind.Local).AddTicks(9487));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 7, 12, 30, 34, 18, DateTimeKind.Local).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 7, 12, 30, 34, 18, DateTimeKind.Local).AddTicks(9499));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 7, 12, 30, 34, 18, DateTimeKind.Local).AddTicks(9500));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 7, 12, 30, 34, 18, DateTimeKind.Local).AddTicks(9501));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 7, 12, 26, 48, 288, DateTimeKind.Local).AddTicks(9839));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 7, 12, 26, 48, 288, DateTimeKind.Local).AddTicks(9851));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 7, 12, 26, 48, 288, DateTimeKind.Local).AddTicks(9853));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 7, 12, 26, 48, 288, DateTimeKind.Local).AddTicks(9855));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 7, 12, 26, 48, 288, DateTimeKind.Local).AddTicks(9857));
        }
    }
}
