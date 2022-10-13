using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaApi.Migrations
{
    public partial class ChangeVillaNumberMOdel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 6, 12, 33, 58, 173, DateTimeKind.Local).AddTicks(3578));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 6, 12, 33, 58, 173, DateTimeKind.Local).AddTicks(3592));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 6, 12, 33, 58, 173, DateTimeKind.Local).AddTicks(3595));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 6, 12, 33, 58, 173, DateTimeKind.Local).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 6, 12, 33, 58, 173, DateTimeKind.Local).AddTicks(3601));
        }
    }
}
