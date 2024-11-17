﻿// <auto-generated />
using System;
using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241014135052_someEntityNameModified")]
    partial class someEntityNameModified
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NationalID")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "123 Main St, Springfield",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1985, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "johndoe@example.com",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "John Doe",
                            NationalID = "1234567890",
                            PhoneNumber = "123-456-7890"
                        },
                        new
                        {
                            CustomerId = 2,
                            Address = "456 Elm St, Springfield",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1990, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "janesmith@example.com",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Jane Smith",
                            NationalID = "0987654321",
                            PhoneNumber = "987-654-3210"
                        },
                        new
                        {
                            CustomerId = 3,
                            Address = "789 Oak St, Metropolis",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1975, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "robertbrown@example.com",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Robert Brown",
                            NationalID = "4567890123",
                            PhoneNumber = "555-123-4567"
                        },
                        new
                        {
                            CustomerId = 4,
                            Address = "321 Pine St, Gotham",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1992, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "emilydavis@example.com",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Emily Davis",
                            NationalID = "3216549870",
                            PhoneNumber = "321-654-9870"
                        },
                        new
                        {
                            CustomerId = 5,
                            Address = "654 Maple St, Star City",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1980, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "michaeljohnson@example.com",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Michael Johnson",
                            NationalID = "9876543210",
                            PhoneNumber = "777-888-9999"
                        });
                });

            modelBuilder.Entity("Entities.Embellishment", b =>
                {
                    b.Property<int>("EmbellishmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmbellishmentDiscription")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmbellishmentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmbellishmentTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsAcitve")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmbellishmentId");

                    b.HasIndex("EmbellishmentTypeId");

                    b.ToTable("Embellishment");

                    b.HasData(
                        new
                        {
                            EmbellishmentId = 1,
                            Cost = 20,
                            EmbellishmentDiscription = "A circular neck style.",
                            EmbellishmentName = "Circle Neck",
                            EmbellishmentTypeId = 1
                        },
                        new
                        {
                            EmbellishmentId = 2,
                            Cost = 25,
                            EmbellishmentDiscription = "A V-shaped neck style.",
                            EmbellishmentName = "V-Neck",
                            EmbellishmentTypeId = 1
                        },
                        new
                        {
                            EmbellishmentId = 3,
                            Cost = 15,
                            EmbellishmentDiscription = "A short sleeve style.",
                            EmbellishmentName = "Short Sleeve",
                            EmbellishmentTypeId = 2
                        },
                        new
                        {
                            EmbellishmentId = 4,
                            Cost = 30,
                            EmbellishmentDiscription = "A long sleeve style.",
                            EmbellishmentName = "Long Sleeve",
                            EmbellishmentTypeId = 2
                        },
                        new
                        {
                            EmbellishmentId = 5,
                            Cost = 10,
                            EmbellishmentDiscription = "A frayed hem style.",
                            EmbellishmentName = "Frayed Hem",
                            EmbellishmentTypeId = 3
                        });
                });

            modelBuilder.Entity("Entities.EmbellishmentType", b =>
                {
                    b.Property<int>("EmbellishmentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmbellishmentTypeDiscription")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmbellishmentTypeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short?>("SortOrder")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmbellishmentTypeId");

                    b.HasIndex("EmbellishmentTypeName")
                        .IsUnique();

                    b.ToTable("EmbellishmentTypes");

                    b.HasData(
                        new
                        {
                            EmbellishmentTypeId = 1,
                            EmbellishmentTypeDiscription = "Various neck styles.",
                            EmbellishmentTypeName = "Neck"
                        },
                        new
                        {
                            EmbellishmentTypeId = 2,
                            EmbellishmentTypeDiscription = "Different sleeve styles.",
                            EmbellishmentTypeName = "Sleeve"
                        },
                        new
                        {
                            EmbellishmentTypeId = 3,
                            EmbellishmentTypeDiscription = "Different hem styles.",
                            EmbellishmentTypeName = "Hem"
                        },
                        new
                        {
                            EmbellishmentTypeId = 4,
                            EmbellishmentTypeDiscription = "Various pocket styles.",
                            EmbellishmentTypeName = "Pocket"
                        },
                        new
                        {
                            EmbellishmentTypeId = 5,
                            EmbellishmentTypeDiscription = "Different embroidery styles.",
                            EmbellishmentTypeName = "Embroidery"
                        });
                });

            modelBuilder.Entity("Entities.Measurement", b =>
                {
                    b.Property<int>("Measurementid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("ArmLength")
                        .HasColumnType("REAL");

                    b.Property<double>("Chest")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Height")
                        .HasColumnType("REAL");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Leg")
                        .HasColumnType("REAL");

                    b.Property<double>("Neck")
                        .HasColumnType("REAL");

                    b.Property<double>("ShoulderWidth")
                        .HasColumnType("REAL");

                    b.Property<double>("Sleeve")
                        .HasColumnType("REAL");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Waist")
                        .HasColumnType("REAL");

                    b.Property<double>("trousers")
                        .HasColumnType("REAL");

                    b.HasKey("Measurementid");

                    b.HasIndex("CustomerId");

                    b.ToTable("Measurements");

                    b.HasData(
                        new
                        {
                            Measurementid = 1,
                            ArmLength = 62.0,
                            Chest = 100.0,
                            CreatedAt = new DateTime(2024, 10, 14, 18, 20, 51, 438, DateTimeKind.Local).AddTicks(8457),
                            CustomerId = 1,
                            Height = 175.5,
                            IsDeleted = false,
                            Leg = 80.0,
                            Neck = 38.0,
                            ShoulderWidth = 45.0,
                            Sleeve = 60.0,
                            Waist = 80.0,
                            trousers = 0.0
                        },
                        new
                        {
                            Measurementid = 2,
                            ArmLength = 63.0,
                            Chest = 101.0,
                            CreatedAt = new DateTime(2024, 10, 14, 18, 20, 51, 438, DateTimeKind.Local).AddTicks(8472),
                            CustomerId = 2,
                            Height = 176.0,
                            IsDeleted = false,
                            Leg = 81.0,
                            Neck = 39.0,
                            ShoulderWidth = 46.0,
                            Sleeve = 61.0,
                            Waist = 81.0,
                            trousers = 0.0
                        },
                        new
                        {
                            Measurementid = 3,
                            ArmLength = 62.5,
                            Chest = 99.0,
                            CreatedAt = new DateTime(2024, 10, 14, 18, 20, 51, 438, DateTimeKind.Local).AddTicks(8474),
                            CustomerId = 3,
                            Height = 175.5,
                            IsDeleted = false,
                            Leg = 79.0,
                            Neck = 38.5,
                            ShoulderWidth = 45.0,
                            Sleeve = 60.5,
                            Waist = 79.0,
                            trousers = 0.0
                        },
                        new
                        {
                            Measurementid = 4,
                            ArmLength = 64.0,
                            Chest = 102.0,
                            CreatedAt = new DateTime(2024, 10, 14, 18, 20, 51, 438, DateTimeKind.Local).AddTicks(8475),
                            CustomerId = 4,
                            Height = 177.0,
                            IsDeleted = false,
                            Leg = 82.0,
                            Neck = 40.0,
                            ShoulderWidth = 46.0,
                            Sleeve = 62.0,
                            Waist = 82.0,
                            trousers = 0.0
                        });
                });

            modelBuilder.Entity("Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ExpectedCompletionDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("TEXT");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Entities.OrderDesign", b =>
                {
                    b.Property<int>("DesignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EmbellishmentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("MeasurementId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DesignId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmbellishmentId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDesigns");
                });

            modelBuilder.Entity("Entities.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("INTEGER");

                    b.HasKey("PaymentId");

                    b.HasIndex("OrderId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Khayati.Core.Domain.Entities.Relative", b =>
                {
                    b.Property<int>("RelativeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("RelationshipType")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("INTEGER");

                    b.HasKey("RelativeId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Relative");
                });

            modelBuilder.Entity("Khayati.Core.Domain.Entities.Translation", b =>
                {
                    b.Property<int>("TranslationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EntityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EntityType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TranslatedValue")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TranslationId");

                    b.ToTable("Translations");
                });

            modelBuilder.Entity("Entities.Embellishment", b =>
                {
                    b.HasOne("Entities.EmbellishmentType", "EmbellishmentType")
                        .WithMany("Embellishmentes")
                        .HasForeignKey("EmbellishmentTypeId");

                    b.Navigation("EmbellishmentType");
                });

            modelBuilder.Entity("Entities.Measurement", b =>
                {
                    b.HasOne("Entities.Customer", "Customer")
                        .WithMany("Measurements")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Entities.Order", b =>
                {
                    b.HasOne("Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Entities.OrderDesign", b =>
                {
                    b.HasOne("Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Embellishment", "Embellishment")
                        .WithMany()
                        .HasForeignKey("EmbellishmentId");

                    b.HasOne("Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Embellishment");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Entities.Payment", b =>
                {
                    b.HasOne("Entities.Order", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Khayati.Core.Domain.Entities.Relative", b =>
                {
                    b.HasOne("Entities.Customer", "Customer")
                        .WithMany("Relatives")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Entities.Customer", b =>
                {
                    b.Navigation("Measurements");

                    b.Navigation("Orders");

                    b.Navigation("Relatives");
                });

            modelBuilder.Entity("Entities.EmbellishmentType", b =>
                {
                    b.Navigation("Embellishmentes");
                });

            modelBuilder.Entity("Entities.Order", b =>
                {
                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}