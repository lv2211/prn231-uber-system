﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UberSystem.Infrastructure;

#nullable disable

namespace UberSystem.Infrastructure.Migrations
{
    [DbContext(typeof(UberSystemDbContext))]
    partial class UberSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CabDriver", b =>
                {
                    b.Property<long>("CabsId")
                        .HasColumnType("bigint");

                    b.Property<long>("DriversId")
                        .HasColumnType("bigint");

                    b.HasKey("CabsId", "DriversId");

                    b.HasIndex("DriversId");

                    b.ToTable("CabDriver");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Cab", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("RegNo")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cabs");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            RegNo = "51A-12345",
                            Type = "Hyundai Accent - Sedan"
                        },
                        new
                        {
                            Id = 2L,
                            RegNo = "30B-67890",
                            Type = "Toyota Camry - Sedan"
                        },
                        new
                        {
                            Id = 3L,
                            RegNo = "29C-54321",
                            Type = "Honda Civic - Sedan"
                        },
                        new
                        {
                            Id = 4L,
                            RegNo = "50D-11223",
                            Type = "Ford Fiesta - Hatchback"
                        },
                        new
                        {
                            Id = 5L,
                            RegNo = "60E-98765",
                            Type = "Kia Sorento - SUV"
                        },
                        new
                        {
                            Id = 6L,
                            RegNo = "45F-22334",
                            Type = "Chevrolet Cruze - Sedan"
                        },
                        new
                        {
                            Id = 7L,
                            RegNo = "51G-99887",
                            Type = "Mazda 3 - Sedan"
                        },
                        new
                        {
                            Id = 8L,
                            RegNo = "48H-45678",
                            Type = "Toyota Fortuner - SUV"
                        },
                        new
                        {
                            Id = 9L,
                            RegNo = "55K-33445",
                            Type = "Hyundai Elantra - Sedan"
                        },
                        new
                        {
                            Id = 10L,
                            RegNo = "61L-56789",
                            Type = "Mitsubishi Xpander - MPV"
                        });
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<byte[]>("CreateAt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreateAt = new byte[] { 68, 202, 169, 80, 29, 228, 220, 136 },
                            UserId = new Guid("dced0a0e-ca60-4014-b23d-796c5d4d3a02")
                        });
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Driver", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("CabId")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("CreateAt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<double?>("LocationLatitude")
                        .HasColumnType("float");

                    b.Property<double?>("LocationLongitude")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreateAt = new byte[] { 135, 202, 169, 80, 29, 228, 220, 136 },
                            Dob = new DateTime(1996, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 0,
                            UserId = new Guid("98388595-6f18-4518-acb1-0718fd336864")
                        });
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Payment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<double?>("Amount")
                        .HasColumnType("float");

                    b.Property<byte[]>("CreateAt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Method")
                        .HasColumnType("nvarchar(255)");

                    b.Property<long?>("TripId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Rating", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DriverId")
                        .HasColumnType("bigint");

                    b.Property<string>("Feedback")
                        .HasColumnType("nvarchar(300)");

                    b.Property<long?>("TripId")
                        .HasColumnType("bigint");

                    b.Property<int?>("TripRating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DriverId");

                    b.HasIndex("TripId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Trip", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<byte[]>("CreateAt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<double?>("DestinationLatitude")
                        .HasColumnType("float");

                    b.Property<double?>("DestinationLongitude")
                        .HasColumnType("float");

                    b.Property<long?>("DriverId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PaymentId")
                        .HasColumnType("bigint");

                    b.Property<double?>("SourceLatitude")
                        .HasColumnType("float");

                    b.Property<double?>("SourceLongitude")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DriverId");

                    b.ToTable("Trips");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreateAt = new byte[] { 209, 162, 8, 253, 87, 228, 220, 8 },
                            CustomerId = 1L,
                            DestinationLatitude = 34.052199999999999,
                            DestinationLongitude = -118.2437,
                            DriverId = 1L,
                            SourceLatitude = 37.774900000000002,
                            SourceLongitude = -122.4194,
                            Status = 1
                        },
                        new
                        {
                            Id = 2L,
                            CreateAt = new byte[] { 213, 162, 8, 253, 87, 228, 220, 8 },
                            CustomerId = 1L,
                            DestinationLatitude = 34.052199999999999,
                            DestinationLongitude = -118.2437,
                            DriverId = 2L,
                            SourceLatitude = 40.712800000000001,
                            SourceLongitude = -74.006,
                            Status = 1
                        },
                        new
                        {
                            Id = 3L,
                            CreateAt = new byte[] { 216, 162, 8, 253, 87, 228, 220, 8 },
                            CustomerId = 4L,
                            DestinationLatitude = 48.8566,
                            DestinationLongitude = 2.3521999999999998,
                            DriverId = 2L,
                            SourceLatitude = 51.507399999999997,
                            SourceLongitude = -0.1278,
                            Status = 1
                        },
                        new
                        {
                            Id = 4L,
                            CreateAt = new byte[] { 219, 162, 8, 253, 87, 228, 220, 8 },
                            CustomerId = 4L,
                            DestinationLatitude = 35.689500000000002,
                            DestinationLongitude = 139.6917,
                            DriverId = 2L,
                            SourceLatitude = 40.712800000000001,
                            SourceLongitude = -74.006,
                            Status = 2
                        });
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("EmailVerified")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("VerifiedToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4407944b-ce49-4ca4-990a-4acbc9a644e0"),
                            Email = "ubersystem.admin.123@example.com",
                            Password = "uberad123!",
                            Role = 2,
                            UserName = "UberSystem Admin"
                        },
                        new
                        {
                            Id = new Guid("98388595-6f18-4518-acb1-0718fd336864"),
                            Email = "totrogias@gmail.com",
                            EmailVerified = true,
                            Password = "matkhau123!",
                            Role = 1,
                            UserName = "Trần Minh Toàn"
                        },
                        new
                        {
                            Id = new Guid("dced0a0e-ca60-4014-b23d-796c5d4d3a02"),
                            Email = "jane.doe@ubersystem.com",
                            EmailVerified = true,
                            Password = "secure_x1!_password",
                            Role = 0,
                            UserName = "janedoe"
                        });
                });

            modelBuilder.Entity("CabDriver", b =>
                {
                    b.HasOne("UberSystem.Domain.Entities.Cab", null)
                        .WithMany()
                        .HasForeignKey("CabsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UberSystem.Domain.Entities.Driver", null)
                        .WithMany()
                        .HasForeignKey("DriversId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Customer", b =>
                {
                    b.HasOne("UberSystem.Domain.Entities.User", "User")
                        .WithMany("Customers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("User");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Driver", b =>
                {
                    b.HasOne("UberSystem.Domain.Entities.User", "User")
                        .WithMany("Drivers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("User");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Payment", b =>
                {
                    b.HasOne("UberSystem.Domain.Entities.Trip", "Trip")
                        .WithMany("Payments")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Rating", b =>
                {
                    b.HasOne("UberSystem.Domain.Entities.Customer", "Customer")
                        .WithMany("Ratings")
                        .HasForeignKey("CustomerId");

                    b.HasOne("UberSystem.Domain.Entities.Driver", "Driver")
                        .WithMany("Ratings")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("UberSystem.Domain.Entities.Trip", "Trip")
                        .WithMany("Ratings")
                        .HasForeignKey("TripId");

                    b.Navigation("Customer");

                    b.Navigation("Driver");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Trip", b =>
                {
                    b.HasOne("UberSystem.Domain.Entities.Customer", "Customer")
                        .WithMany("Trips")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("UberSystem.Domain.Entities.Driver", "Driver")
                        .WithMany("Trips")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Customer");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("Trips");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Driver", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("Trips");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.Trip", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("UberSystem.Domain.Entities.User", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Drivers");
                });
#pragma warning restore 612, 618
        }
    }
}
