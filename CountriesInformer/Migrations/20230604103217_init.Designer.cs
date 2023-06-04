﻿// <auto-generated />
using CountriesInformer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CountriesInformer.Migrations
{
    [DbContext(typeof(CountriesDbContext))]
    [Migration("20230604103217_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CountriesInformer.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CapitalCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OfficialLanguage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CapitalCity = "Astana",
                            Name = "Kazakhstan",
                            OfficialLanguage = "Kazakh"
                        },
                        new
                        {
                            Id = 2,
                            CapitalCity = "Tashkent",
                            Name = "Uzbekistan",
                            OfficialLanguage = "Uzbek"
                        },
                        new
                        {
                            Id = 3,
                            CapitalCity = "Tbilisi",
                            Name = "Georgia",
                            OfficialLanguage = "Georgian"
                        },
                        new
                        {
                            Id = 4,
                            CapitalCity = "Kabul",
                            Name = "Afghanistan",
                            OfficialLanguage = "Pashto"
                        },
                        new
                        {
                            Id = 5,
                            CapitalCity = "Tehran",
                            Name = "Iran",
                            OfficialLanguage = "Iranian"
                        },
                        new
                        {
                            Id = 6,
                            CapitalCity = "Riyadh",
                            Name = "Saudi Arabia",
                            OfficialLanguage = "Arabic"
                        },
                        new
                        {
                            Id = 7,
                            CapitalCity = "Islamabad",
                            Name = "Pakistan",
                            OfficialLanguage = "Urdu"
                        },
                        new
                        {
                            Id = 8,
                            CapitalCity = "Algiers",
                            Name = "Algeria",
                            OfficialLanguage = "Arabic"
                        },
                        new
                        {
                            Id = 9,
                            CapitalCity = "Ashgabat",
                            Name = "Turkmenistan",
                            OfficialLanguage = "Turkmen"
                        },
                        new
                        {
                            Id = 10,
                            CapitalCity = "Ulaanbaatar",
                            Name = "Mongolia",
                            OfficialLanguage = "Mongolian"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
