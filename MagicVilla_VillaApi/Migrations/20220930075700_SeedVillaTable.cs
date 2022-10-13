using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaApi.Migrations
{
    public partial class SeedVillaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "chgitem inch chgitem vonc", "https://gallery.streamlinevrs.com/units-gallery/00/06/4C/image_162708236.jpeg", "Royal Villa", 4, 200.0, 250, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "chgitem inch chgitem vonc", "https://cache.desktopnexus.com/thumbseg/456/456996-bigthumbnail.jpg", "Pink Villa", 10, 100.0, 300, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "chgitem inch chgitem vonc", "https://www.amazingarchitecture.com/photos/5/Reza%20Mohatashami/Black%20Villa/Black-Villa-Reza-Mohtashami-New-York-USA-001.jpg", "Black Villa", 6, 200.0, 300, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "chgitem inch chgitem vonc", "https://vwartclub.com/media/projects/4198/1.jpg", "Minimalistic Villa", 7, 200.0, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "chgitem inch chgitem vonc", "https://www.luxury-architecture.net/wp-content/uploads/2018/04/1522725431-6222-16x9-0-51-848.20170803170501.jpg", "Italiano Villa", 28, 400.0, 3700, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
