﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortfolioHerryWijaya.Data;

#nullable disable

namespace PortfolioHerryWijaya.Migrations
{
    [DbContext(typeof(PortfolioDbContext))]
    [Migration("20250110042947_project3newnew")]
    partial class project3newnew
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PortfolioHerryWijaya.Models.Domain.DaysGoneWeapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Condition")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DaysGoneWeapons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Condition = 1,
                            Name = "SAF",
                            Source = "Pick Up",
                            Type = "Assault Rifle"
                        },
                        new
                        {
                            Id = 2,
                            Condition = 3,
                            Name = "MWS",
                            Source = "Hot Springs",
                            Type = "Assault Rifle"
                        },
                        new
                        {
                            Id = 3,
                            Condition = 3,
                            Name = "US556",
                            Source = "Hot Springs",
                            Type = "Assault Rifle"
                        },
                        new
                        {
                            Id = 4,
                            Condition = 1,
                            Name = "M7",
                            Source = "Pick Up",
                            Type = "Rifle"
                        },
                        new
                        {
                            Id = 5,
                            Condition = 2,
                            Name = ".22 Repeater",
                            Source = "Hot Springs",
                            Type = "Rifle"
                        },
                        new
                        {
                            Id = 6,
                            Condition = 5,
                            Name = "Liberator",
                            Source = "Iron Mike's",
                            Type = "Shotgun"
                        },
                        new
                        {
                            Id = 7,
                            Condition = 4,
                            Name = "PPSH-41",
                            Source = "Wizard Island",
                            Type = "SMG"
                        },
                        new
                        {
                            Id = 8,
                            Condition = 3,
                            Name = "SWAT-10",
                            Source = "Iron Mike's",
                            Type = "SMG"
                        });
                });

            modelBuilder.Entity("PortfolioHerryWijaya.Models.Domain.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("PortfolioHerryWijaya.Models.Domain.Portfolio3.Gacha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GachaItemPercentages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GachaItems")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gachas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "10% chance to get Ultimate Freyna Surprise Box (Contains unique cosmetics, taunts, skins, and animations for Ultimate Freyna)",
                            GachaItemPercentages = "[30,30,10,15,15]",
                            GachaItems = "[\"1 Million Gold\",\"1 Million Kuiper\",\"Ultimate Freyna Surprise Box\",\"Crystallization Catalyst\",\"Energy Activator\"]",
                            ImageUrl = "ultimatefreyna.png",
                            Name = "Ultimate Freyna Pick Up Gacha"
                        },
                        new
                        {
                            Id = 2,
                            Description = "20% chance to get Ines Surprise Box (Contains Ines fragments and 1% chance of obtaining Ines's unique skin)",
                            GachaItemPercentages = "[20,20,20,20,20]",
                            GachaItems = "[\"Ultimate Weapon Surprise Box\",\"Ultimate Reactor Surprise Box\",\"Ines Surprise Box\",\"Crystallization Catalyst\",\"Energy Activator\"]",
                            ImageUrl = "ines.png",
                            Name = "Ultimate Ines Pick Up Gacha"
                        });
                });

            modelBuilder.Entity("PortfolioHerryWijaya.Models.Domain.Portfolio3.GachaItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GachaItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "1 Million Gold"
                        },
                        new
                        {
                            Id = 2,
                            Name = "1 Million Kuiper"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ultimate Freyna Surprise Box"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Crystallization Catalyst"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Ultimate Valby Surprise Box"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Energy Activator"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Ultimate Weapon Surprise Box"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Ultimate Reactor Surprise Box"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
