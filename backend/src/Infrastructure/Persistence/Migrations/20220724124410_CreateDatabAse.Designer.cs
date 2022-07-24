﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20220724124410_CreateDatabAse")]
    partial class CreateDatabAse
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("43db034a-98cc-42ee-8fff-c57016484f4d"),
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailConfirmationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("EmailConfirmedCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ResetPasswordCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e"),
                            Email = "defaultadmin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Default",
                            LastName = "Admin",
                            PasswordHash = new byte[] { 220, 149, 29, 195, 169, 103, 33, 247, 157, 222, 254, 197, 158, 211, 132, 71, 37, 16, 232, 129, 51, 77, 61, 178, 76, 136, 181, 132, 222, 193, 230, 252, 198, 170, 8, 184, 147, 91, 86, 75, 195, 35, 212, 50, 168, 28, 109, 173, 202, 82, 121, 7, 92, 59, 122, 211, 15, 33, 56, 132, 48, 64, 114, 239 },
                            PasswordSalt = new byte[] { 251, 163, 36, 238, 210, 186, 11, 186, 74, 23, 250, 90, 132, 114, 157, 226, 112, 187, 42, 63, 18, 195, 142, 207, 142, 236, 155, 24, 135, 29, 234, 12, 241, 233, 160, 133, 150, 200, 202, 16, 91, 26, 57, 187, 140, 58, 119, 1, 232, 225, 166, 104, 60, 44, 227, 101, 113, 223, 27, 225, 95, 153, 10, 215, 164, 87, 250, 3, 150, 114, 5, 69, 172, 212, 47, 48, 120, 76, 138, 247, 49, 112, 51, 196, 71, 42, 224, 36, 184, 136, 24, 165, 225, 98, 54, 199, 88, 8, 128, 226, 8, 18, 207, 149, 77, 208, 153, 135, 192, 151, 149, 163, 6, 101, 142, 147, 198, 20, 117, 184, 247, 65, 15, 180, 103, 193, 189, 132 },
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e"),
                            RoleId = new Guid("43db034a-98cc-42ee-8fff-c57016484f4d")
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}