﻿// <auto-generated />
using System;
using DanilaWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DanilaWebApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191122123514_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DanilaWebApp.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalLocation")
                        .HasMaxLength(125);

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<bool>("SelfExport");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("DanilaWebApp.Models.CommunicationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommunicationName")
                        .IsRequired();

                    b.Property<string>("CommunicationSubType")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("CommunicationTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommunicationName = "4G",
                            CommunicationSubType = "IMT Advanced"
                        },
                        new
                        {
                            Id = 2,
                            CommunicationName = "4G",
                            CommunicationSubType = "LTE Advanced Pro"
                        },
                        new
                        {
                            Id = 3,
                            CommunicationName = "3G",
                            CommunicationSubType = "LTE"
                        });
                });

            modelBuilder.Entity("DanilaWebApp.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<string>("ContactPhone")
                        .IsRequired();

                    b.Property<int>("ProfileId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("ProfileId")
                        .IsUnique();

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DanilaWebApp.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacteristicId");

                    b.Property<string>("Company")
                        .IsRequired();

                    b.Property<int>("OrderId");

                    b.Property<int>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CharacteristicId")
                        .IsUnique();

                    b.HasIndex("OrderId");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("DanilaWebApp.Models.PhoneCharacteristic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CpuModel")
                        .IsRequired();

                    b.Property<int>("PhoneDepth");

                    b.Property<int>("PhoneHeight");

                    b.Property<int>("PhoneWidth");

                    b.Property<string>("ScreenType")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("opSystem")
                        .IsRequired();

                    b.Property<string>("type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("PhoneCharacteristics");
                });

            modelBuilder.Entity("DanilaWebApp.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("Name");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("DanilaWebApp.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "user"
                        });
                });

            modelBuilder.Entity("DanilaWebApp.Models.SupportedCommunicationType", b =>
                {
                    b.Property<int>("CommunicationTypeId");

                    b.Property<int>("PhoneCharacteristicId");

                    b.Property<int>("Id");

                    b.HasKey("CommunicationTypeId", "PhoneCharacteristicId");

                    b.HasIndex("PhoneCharacteristicId");

                    b.ToTable("SupportedCommunicationTypes");
                });

            modelBuilder.Entity("DanilaWebApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("Password");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<int?>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "adminka",
                            Password = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                            RegistrationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("DanilaWebApp.Models.Order", b =>
                {
                    b.HasOne("DanilaWebApp.Models.Address", "Address")
                        .WithOne("Order")
                        .HasForeignKey("DanilaWebApp.Models.Order", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DanilaWebApp.Models.Profile", "Profile")
                        .WithOne("Order")
                        .HasForeignKey("DanilaWebApp.Models.Order", "ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DanilaWebApp.Models.Phone", b =>
                {
                    b.HasOne("DanilaWebApp.Models.PhoneCharacteristic", "Characteristic")
                        .WithOne("Phone")
                        .HasForeignKey("DanilaWebApp.Models.Phone", "CharacteristicId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DanilaWebApp.Models.Order", "Order")
                        .WithMany("Phones")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DanilaWebApp.Models.Profile", b =>
                {
                    b.HasOne("DanilaWebApp.Models.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("DanilaWebApp.Models.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DanilaWebApp.Models.SupportedCommunicationType", b =>
                {
                    b.HasOne("DanilaWebApp.Models.CommunicationType", "CommunicationType")
                        .WithMany("SupportedCommunicationTypes")
                        .HasForeignKey("CommunicationTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DanilaWebApp.Models.PhoneCharacteristic", "PhoneCharacteristic")
                        .WithMany("SupportedCommunicationTypes")
                        .HasForeignKey("PhoneCharacteristicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DanilaWebApp.Models.User", b =>
                {
                    b.HasOne("DanilaWebApp.Models.Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
