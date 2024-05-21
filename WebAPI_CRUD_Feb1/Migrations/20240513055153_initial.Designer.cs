﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI_CRUD_Feb1.Models;

#nullable disable

namespace WebAPI_CRUD_Feb1.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20240513055153_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPI_CRUD_Feb1.Models.Product", b =>
                {
                    b.Property<int>("PId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PId"));

                    b.Property<DateTime>("DOP")
                        .HasColumnType("datetime2");

                    b.Property<string>("PName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("PId");

                    b.ToTable("tblProduct");

                    b.HasData(
                        new
                        {
                            PId = 1,
                            DOP = new DateTime(2000, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PName = "Mobile",
                            Price = 19000
                        },
                        new
                        {
                            PId = 2,
                            DOP = new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PName = "TV",
                            Price = 30000
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
