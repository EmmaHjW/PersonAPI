﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonAPI.Data;

#nullable disable

namespace PersonAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PersonAPI.Models.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FK_PersonId")
                        .HasColumnType("int");

                    b.HasKey("InterestId");

                    b.HasIndex("FK_PersonId");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            InterestId = 1,
                            Description = "Trail running",
                            FK_PersonId = 1
                        },
                        new
                        {
                            InterestId = 2,
                            Description = "Food & Wine",
                            FK_PersonId = 1
                        },
                        new
                        {
                            InterestId = 3,
                            Description = "Coding",
                            FK_PersonId = 2
                        });
                });

            modelBuilder.Entity("PersonAPI.Models.Link", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinkId"));

                    b.Property<int>("FK_InterestId")
                        .HasColumnType("int");

                    b.Property<int?>("InterestsInterestId")
                        .HasColumnType("int");

                    b.Property<string>("LinkName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LinkId");

                    b.HasIndex("InterestsInterestId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("PersonAPI.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            BirthDate = new DateTime(1990, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Emma Hjalmarsson Wahlström",
                            PhoneNumber = "0738435459"
                        },
                        new
                        {
                            PersonId = 2,
                            BirthDate = new DateTime(1992, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Aldor Besher",
                            PhoneNumber = "0738435455"
                        },
                        new
                        {
                            PersonId = 3,
                            BirthDate = new DateTime(1982, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Oskar Ullsten",
                            PhoneNumber = "0738435465"
                        });
                });

            modelBuilder.Entity("PersonAPI.Models.Interest", b =>
                {
                    b.HasOne("PersonAPI.Models.Person", "Persons")
                        .WithMany("Interests")
                        .HasForeignKey("FK_PersonId");

                    b.Navigation("Persons");
                });

            modelBuilder.Entity("PersonAPI.Models.Link", b =>
                {
                    b.HasOne("PersonAPI.Models.Interest", "Interests")
                        .WithMany("Links")
                        .HasForeignKey("InterestsInterestId");

                    b.Navigation("Interests");
                });

            modelBuilder.Entity("PersonAPI.Models.Interest", b =>
                {
                    b.Navigation("Links");
                });

            modelBuilder.Entity("PersonAPI.Models.Person", b =>
                {
                    b.Navigation("Interests");
                });
#pragma warning restore 612, 618
        }
    }
}
