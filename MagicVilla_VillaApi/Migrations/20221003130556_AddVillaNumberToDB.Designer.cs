﻿// <auto-generated />
using System;
using MagicVilla_VillaApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla_VillaApi.Migrations
{
    [DbContext(typeof(AplicationDBContext))]
    [Migration("20221003130556_AddVillaNumberToDB")]
    partial class AddVillaNumberToDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MagicVilla_VillaApi.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Amenity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "",
                            CreatedDate = new DateTime(2022, 10, 3, 17, 5, 55, 943, DateTimeKind.Local).AddTicks(9815),
                            Details = "chgitem inch chgitem vonc",
                            ImageUrl = "https://gallery.streamlinevrs.com/units-gallery/00/06/4C/image_162708236.jpeg",
                            Name = "Royal Villa",
                            Occupancy = 4,
                            Rate = 200.0,
                            Sqft = 250,
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "",
                            CreatedDate = new DateTime(2022, 10, 3, 17, 5, 55, 943, DateTimeKind.Local).AddTicks(9830),
                            Details = "chgitem inch chgitem vonc",
                            ImageUrl = "https://cache.desktopnexus.com/thumbseg/456/456996-bigthumbnail.jpg",
                            Name = "Pink Villa",
                            Occupancy = 10,
                            Rate = 100.0,
                            Sqft = 300,
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "",
                            CreatedDate = new DateTime(2022, 10, 3, 17, 5, 55, 943, DateTimeKind.Local).AddTicks(9832),
                            Details = "chgitem inch chgitem vonc",
                            ImageUrl = "https://www.amazingarchitecture.com/photos/5/Reza%20Mohatashami/Black%20Villa/Black-Villa-Reza-Mohtashami-New-York-USA-001.jpg",
                            Name = "Black Villa",
                            Occupancy = 6,
                            Rate = 200.0,
                            Sqft = 300,
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Amenity = "",
                            CreatedDate = new DateTime(2022, 10, 3, 17, 5, 55, 943, DateTimeKind.Local).AddTicks(9833),
                            Details = "chgitem inch chgitem vonc",
                            ImageUrl = "https://vwartclub.com/media/projects/4198/1.jpg",
                            Name = "Minimalistic Villa",
                            Occupancy = 7,
                            Rate = 200.0,
                            Sqft = 500,
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Amenity = "",
                            CreatedDate = new DateTime(2022, 10, 3, 17, 5, 55, 943, DateTimeKind.Local).AddTicks(9835),
                            Details = "chgitem inch chgitem vonc",
                            ImageUrl = "https://www.luxury-architecture.net/wp-content/uploads/2018/04/1522725431-6222-16x9-0-51-848.20170803170501.jpg",
                            Name = "Italiano Villa",
                            Occupancy = 28,
                            Rate = 400.0,
                            Sqft = 3700,
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MagicVilla_VillaApi.Models.VillaNumber", b =>
                {
                    b.Property<int>("VillaNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpetialDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("VillaNo");

                    b.ToTable("VillaNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
