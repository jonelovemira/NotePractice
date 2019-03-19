﻿// <auto-generated />
using System;
using CodeLibraryForDotNetCore.UsePostgresql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CodeLibraryForDotNetCore.Migrations
{
    [DbContext(typeof(TestDbContext))]
    [Migration("20190319061742_update_ForeignKeys")]
    partial class update_ForeignKeys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Npgsql:PostgresExtension:postgis", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CodeLibraryForDotNetCore.UsePostgresql.Models.Dog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Sex");

                    b.HasKey("Id");

                    b.ToTable("Dogs");
                });

            modelBuilder.Entity("CodeLibraryForDotNetCore.UsePostgresql.Models.UseGeometry.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CityName");

                    b.Property<long?>("CountryId");

                    b.Property<Point>("Location");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("CodeLibraryForDotNetCore.UsePostgresql.Models.UseGeometry.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Polygon>("Border");

                    b.Property<string>("CountryName");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CodeLibraryForDotNetCore.UsePostgresql.Models.UseGeometry.Road", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CityId");

                    b.Property<LineString>("Line");

                    b.Property<string>("RoadName");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Roads");
                });

            modelBuilder.Entity("CodeLibraryForDotNetCore.UsePostgresql.Models.UseGeometry.City", b =>
                {
                    b.HasOne("CodeLibraryForDotNetCore.UsePostgresql.Models.UseGeometry.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("CodeLibraryForDotNetCore.UsePostgresql.Models.UseGeometry.Road", b =>
                {
                    b.HasOne("CodeLibraryForDotNetCore.UsePostgresql.Models.UseGeometry.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");
                });
#pragma warning restore 612, 618
        }
    }
}
