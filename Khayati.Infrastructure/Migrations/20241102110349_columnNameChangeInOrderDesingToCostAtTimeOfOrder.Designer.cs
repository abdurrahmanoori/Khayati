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
    [Migration("20241102110349_columnNameChangeInOrderDesingToCostAtTimeOfOrder")]
    partial class columnNameChangeInOrderDesingToCostAtTimeOfOrder
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

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmbellishmentTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsAcitve")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EmbellishmentId");

                    b.HasIndex("EmbellishmentTypeId");

                    b.ToTable("Embellishment");

                    b.HasData(
                        new
                        {
                            EmbellishmentId = 1,
                            Cost = 20,
                            Description = "A circular neck style.",
                            EmbellishmentTypeId = 1,
                            Name = "Circle Neck"
                        },
                        new
                        {
                            EmbellishmentId = 2,
                            Cost = 25,
                            Description = "A V-shaped neck style.",
                            EmbellishmentTypeId = 1,
                            Name = "V-Neck"
                        },
                        new
                        {
                            EmbellishmentId = 3,
                            Cost = 15,
                            Description = "A short sleeve style.",
                            EmbellishmentTypeId = 2,
                            Name = "Short Sleeve"
                        },
                        new
                        {
                            EmbellishmentId = 4,
                            Cost = 30,
                            Description = "A long sleeve style.",
                            EmbellishmentTypeId = 2,
                            Name = "Long Sleeve"
                        },
                        new
                        {
                            EmbellishmentId = 5,
                            Cost = 10,
                            Description = "A frayed hem style.",
                            EmbellishmentTypeId = 3,
                            Name = "Frayed Hem"
                        });
                });

            modelBuilder.Entity("Entities.EmbellishmentType", b =>
                {
                    b.Property<int>("EmbellishmentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short?>("SortOrder")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmbellishmentTypeId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("EmbellishmentTypes");

                    b.HasData(
                        new
                        {
                            EmbellishmentTypeId = 1,
                            Description = "Various neck styles.",
                            Name = "Neck"
                        },
                        new
                        {
                            EmbellishmentTypeId = 2,
                            Description = "Different sleeve styles.",
                            Name = "Sleeve"
                        },
                        new
                        {
                            EmbellishmentTypeId = 3,
                            Description = "Different hem styles.",
                            Name = "Hem"
                        },
                        new
                        {
                            EmbellishmentTypeId = 4,
                            Description = "Various pocket styles.",
                            Name = "Pocket"
                        },
                        new
                        {
                            EmbellishmentTypeId = 5,
                            Description = "Different embroidery styles.",
                            Name = "Embroidery"
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

                    b.Property<decimal?>("Cost")
                        .HasColumnType("TEXT");

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

                    b.Property<int?>("FabricId")
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

                    b.HasIndex("FabricId");

                    b.ToTable("Measurements");
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

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

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

                    b.Property<decimal?>("CostAtTimeOfOrder")
                        .HasColumnType("TEXT");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EmbellishmentId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FabricId")
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

                    b.HasIndex("FabricId");

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

            modelBuilder.Entity("Khayati.Core.Domain.Entities.Fabric", b =>
                {
                    b.Property<int>("FabricId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("CostPerMeter")
                        .HasColumnType("TEXT");

                    b.Property<string>("Durability")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FabricType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Pattern")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short>("Thickness")
                        .HasColumnType("INTEGER");

                    b.HasKey("FabricId");

                    b.ToTable("Fabrics");

                    b.HasData(
                        new
                        {
                            FabricId = 1,
                            Color = "White",
                            CostPerMeter = 25.5m,
                            Durability = "High",
                            FabricType = "Cotton",
                            Pattern = "Plain",
                            Thickness = (short)5
                        },
                        new
                        {
                            FabricId = 2,
                            Color = "Red",
                            CostPerMeter = 50.75m,
                            Durability = "Medium",
                            FabricType = "Silk",
                            Pattern = "Floral",
                            Thickness = (short)2
                        },
                        new
                        {
                            FabricId = 3,
                            Color = "Blue",
                            CostPerMeter = 15.0m,
                            Durability = "High",
                            FabricType = "Polyester",
                            Pattern = "Striped",
                            Thickness = (short)3
                        });
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

            modelBuilder.Entity("Khayati.Infrastructure.Identity.Entity.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Khayati.Infrastructure.Identity.Entity.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
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

                    b.HasOne("Khayati.Core.Domain.Entities.Fabric", "Fabric")
                        .WithMany()
                        .HasForeignKey("FabricId");

                    b.Navigation("Customer");

                    b.Navigation("Fabric");
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
                        .WithMany("OrderDesigns")
                        .HasForeignKey("EmbellishmentId");

                    b.HasOne("Khayati.Core.Domain.Entities.Fabric", "Fabric")
                        .WithMany()
                        .HasForeignKey("FabricId");

                    b.HasOne("Entities.Order", "Order")
                        .WithMany("OrderDesigns")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Embellishment");

                    b.Navigation("Fabric");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Khayati.Infrastructure.Identity.Entity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Khayati.Infrastructure.Identity.Entity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Khayati.Infrastructure.Identity.Entity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Khayati.Infrastructure.Identity.Entity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Khayati.Infrastructure.Identity.Entity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Khayati.Infrastructure.Identity.Entity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Customer", b =>
                {
                    b.Navigation("Measurements");

                    b.Navigation("Orders");

                    b.Navigation("Relatives");
                });

            modelBuilder.Entity("Entities.Embellishment", b =>
                {
                    b.Navigation("OrderDesigns");
                });

            modelBuilder.Entity("Entities.EmbellishmentType", b =>
                {
                    b.Navigation("Embellishmentes");
                });

            modelBuilder.Entity("Entities.Order", b =>
                {
                    b.Navigation("OrderDesigns");

                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
