﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TutorHubAPI.Data;

#nullable disable

namespace TutorHubAPI.Migrations
{
    [DbContext(typeof(TutorHubAPIDbContext))]
    [Migration("20241024142831_Added column Naslov to Oglas table")]
    partial class AddedcolumnNaslovtoOglastable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "630c2425-23cf-4da9-be77-e8dc8d20eb79",
                            ConcurrencyStamp = "630c2425-23cf-4da9-be77-e8dc8d20eb79",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "x37s5q0m6r4m-myy5g3bt8lws5rhu1ocym7p",
                            ConcurrencyStamp = "x37s5q0m6r4m-myy5g3bt8lws5rhu1ocym7p",
                            Name = "Professor",
                            NormalizedName = "PROFESSOR"
                        },
                        new
                        {
                            Id = "fff052ce-b85c-4131-b667-617640718911",
                            ConcurrencyStamp = "fff052ce-b85c-4131-b667-617640718911",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PredmetProfesor", b =>
                {
                    b.Property<int>("PredmetsId")
                        .HasColumnType("int");

                    b.Property<int>("ProfesorsId")
                        .HasColumnType("int");

                    b.HasKey("PredmetsId", "ProfesorsId");

                    b.HasIndex("ProfesorsId");

                    b.ToTable("PredmetProfesor");
                });

            modelBuilder.Entity("TutorHubAPI.Models.Domain.Korisnik", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("TutorHubAPI.Models.Domain.Ocene", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Id_Komentatora")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Id_Profesora")
                        .HasColumnType("int");

                    b.Property<string>("Komentar")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<double>("Ocena")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Id_Komentatora");

                    b.HasIndex("Id_Profesora");

                    b.ToTable("Ocene");
                });

            modelBuilder.Entity("TutorHubAPI.Models.Domain.Oglas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<int>("Id_Predmeta")
                        .HasColumnType("int");

                    b.Property<int>("Id_Profesora")
                        .HasColumnType("int");

                    b.Property<string>("Namenjeno_Obrazovanje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naslov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Id_Predmeta");

                    b.HasIndex("Id_Profesora");

                    b.ToTable("Oglas");
                });

            modelBuilder.Entity("TutorHubAPI.Models.Domain.Predmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Predmet");
                });

            modelBuilder.Entity("TutorHubAPI.Models.Domain.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Grad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Id_Korisnik")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Ocena")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(10.0);

                    b.Property<string>("bio")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("pfpUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Korisnik");

                    b.ToTable("Profesor");
                });

            modelBuilder.Entity("TutorHubAPI.Models.Domain.Termini", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Br_ucenika")
                        .HasColumnType("int");

                    b.Property<int>("Id_Oglasa")
                        .HasColumnType("int");

                    b.Property<string>("vreme_Od_Do")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Oglasa");

                    b.ToTable("Termini");
                });

            modelBuilder.Entity("TutorHubAPI.Models.Domain.Zakazani", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_Oglasa")
                        .HasColumnType("int");

                    b.Property<int>("Id_Profesora")
                        .HasColumnType("int");

                    b.Property<string>("Id_Ucenika")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("vremeDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("vremeOd_Do")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Oglasa")
                        .IsUnique();

                    b.HasIndex("Id_Profesora");

                    b.HasIndex("Id_Ucenika");

                    b.ToTable("Zakazani");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TutorHubAPI.Models.Domain.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TutorHubAPI.Models.Domain.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TutorHubAPI.Models.Domain.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TutorHubAPI.Models.Domain.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PredmetProfesor", b =>
                {
                    b.HasOne("TutorHubAPI.Models.Domain.Predmet", null)
                        .WithMany()
                        .HasForeignKey("PredmetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TutorHubAPI.Models.Domain.Profesor", null)
                        .WithMany()
                        .HasForeignKey("ProfesorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TutorHubAPI.Models.Domain.Ocene", b =>
                {
                    b.HasOne("TutorHubAPI.Models.Domain.Korisnik", "Korisnik")
                        .WithMany("Ocenes")
                        .HasForeignKey("Id_Komentatora")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TutorHubAPI.Models.Domain.Profesor", "Profesor")
                        .WithMany("Ocenes")
                        .HasForeignKey("Id_Profesora")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("TutorHubAPI.Models.Domain.Oglas", b =>
                {
                    b.HasOne("TutorHubAPI.Models.Domain.Predmet", "Predmet")
                        .WithMany("Oglas")
                        .HasForeignKey("Id_Predmeta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TutorHubAPI.Models.Domain.Profesor", "Profesor")
                        .WithMany("Oglas")
                        .HasForeignKey("Id_Profesora")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Predmet");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("TutorHubAPI.Models.Domain.Profesor", b =>
                {
                    b.HasOne("TutorHubAPI.Models.Domain.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("Id_Korisnik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("TutorHubAPI.Models.Domain.Termini", b =>
                {
                    b.HasOne("TutorHubAPI.Models.Domain.Oglas", "Oglas")
                        .WithMany("Terminis")
                        .HasForeignKey("Id_Oglasa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oglas");
                });

            modelBuilder.Entity("TutorHubAPI.Models.Domain.Zakazani", b =>
                {
                    b.HasOne("TutorHubAPI.Models.Domain.Oglas", "Oglas")
                        .WithOne("Zakazani")
                        .HasForeignKey("TutorHubAPI.Models.Domain.Zakazani", "Id_Oglasa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TutorHubAPI.Models.Domain.Profesor", "Profesor")
                        .WithMany("Zakazanis")
                        .HasForeignKey("Id_Profesora")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TutorHubAPI.Models.Domain.Korisnik", "Korisnik")
                        .WithMany("Zakazanis")
                        .HasForeignKey("Id_Ucenika")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Oglas");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("TutorHubAPI.Models.Domain.Korisnik", b =>
                {
                    b.Navigation("Ocenes");

                    b.Navigation("Zakazanis");
                });

            modelBuilder.Entity("TutorHubAPI.Models.Domain.Oglas", b =>
                {
                    b.Navigation("Terminis");

                    b.Navigation("Zakazani")
                        .IsRequired();
                });

            modelBuilder.Entity("TutorHubAPI.Models.Domain.Predmet", b =>
                {
                    b.Navigation("Oglas");
                });

            modelBuilder.Entity("TutorHubAPI.Models.Domain.Profesor", b =>
                {
                    b.Navigation("Ocenes");

                    b.Navigation("Oglas");

                    b.Navigation("Zakazanis");
                });
#pragma warning restore 612, 618
        }
    }
}