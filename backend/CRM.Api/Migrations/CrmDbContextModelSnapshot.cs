﻿// <auto-generated />
using System;
using CRM.Api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CRM.Api.Migrations
{
    [DbContext(typeof(CrmDbContext))]
    partial class CrmDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CRM.Api.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .HasDatabaseName("IX_Customers_Email");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_Customers_Name");

                    b.HasIndex("Status")
                        .HasDatabaseName("IX_Customers_Status");

                    b.ToTable("customer", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c3d8905a-6f12-4f4e-a0d3-74a14d4c7bc4"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2229),
                            Email = "john@example.com",
                            Name = "John Doe",
                            PhoneNumber = "1234567890",
                            Status = "Active",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("2b80ae8a-8a09-4f8f-b5c8-cb5280eb7a5e"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2234),
                            Email = "jane@example.com",
                            Name = "Jane Smith",
                            PhoneNumber = "0987654321",
                            Status = "Lead",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("7f6c67f5-6f0b-4e5e-9ed9-b58f7cf6010e"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2237),
                            Email = "bob@example.com",
                            Name = "Bob Johnson",
                            PhoneNumber = "1112223333",
                            Status = "Non-Active",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("ef47f567-2b2c-4d8d-9c51-66369c0f9fa1"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2239),
                            Email = "alice@example.com",
                            Name = "Alice Williams",
                            PhoneNumber = "4445556666",
                            Status = "Active",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("cd43a7a6-3d9f-471e-81ae-ecc6edcb8ab1"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2240),
                            Email = "charlie@example.com",
                            Name = "Charlie Brown",
                            PhoneNumber = "7778889999",
                            Status = "Lead",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("abf58660-f942-4632-b76d-93174ee7ac41"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2242),
                            Email = "david@example.com",
                            Name = "David Miller",
                            PhoneNumber = "1231231234",
                            Status = "Active",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("f748b8be-82f7-4ec0-86b7-8a5e35e94727"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2249),
                            Email = "emma@example.com",
                            Name = "Emma Davis",
                            PhoneNumber = "4564564567",
                            Status = "Non-Active",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("3e8efcc8-07fa-4f53-9477-e3eaf34b98ed"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2251),
                            Email = "frank@example.com",
                            Name = "Frank Wilson",
                            PhoneNumber = "7897897890",
                            Status = "Active",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("e0b94f78-2257-4964-a20c-6bc5149d1ae2"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2253),
                            Email = "grace@example.com",
                            Name = "Grace Lee",
                            PhoneNumber = "2342342345",
                            Status = "Lead",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("efcfd745-6b30-4b41-8a6f-e779baf53175"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2254),
                            Email = "henry@example.com",
                            Name = "Henry Thomas",
                            PhoneNumber = "5675675678",
                            Status = "Non-Active",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("3c1c68e1-847f-4059-b9f8-184f92300959"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2256),
                            Email = "isabella@example.com",
                            Name = "Isabella Moore",
                            PhoneNumber = "8908908901",
                            Status = "Active",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("7328f51c-5e1b-4b57-9d64-b4817d4939d5"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2258),
                            Email = "jack@example.com",
                            Name = "Jack Taylor",
                            PhoneNumber = "1231234567",
                            Status = "Lead",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("3dfb1384-f037-41da-b84e-4d78fd67b13b"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2260),
                            Email = "liam@example.com",
                            Name = "Liam Anderson",
                            PhoneNumber = "9876543210",
                            Status = "Non-Active",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("63b2c62b-f405-4f0e-8a26-b5896fdcc10d"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2262),
                            Email = "mia@example.com",
                            Name = "Mia Thomas",
                            PhoneNumber = "6543210987",
                            Status = "Active",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("70f028c5-fd6c-4a76-87f4-456c1aefb4e3"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2263),
                            Email = "noah@example.com",
                            Name = "Noah Garcia",
                            PhoneNumber = "3456789012",
                            Status = "Lead",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("31c8c8b8-d3fa-44a2-b4d2-7c85ed57453a"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2265),
                            Email = "olivia@example.com",
                            Name = "Olivia Martinez",
                            PhoneNumber = "4567890123",
                            Status = "Non-Active",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("29bdb80b-1768-4eeb-83e7-5ed94c7755d4"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2267),
                            Email = "sophia@example.com",
                            Name = "Sophia Hernandez",
                            PhoneNumber = "5678901234",
                            Status = "Active",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("e4eae6cb-79ed-41e1-b075-1db5a38b9647"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2269),
                            Email = "lucas@example.com",
                            Name = "Lucas Lopez",
                            PhoneNumber = "6789012345",
                            Status = "Lead",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("a2c7e550-bd9b-40fc-8b62-01c6270e18be"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2270),
                            Email = "ethan@example.com",
                            Name = "Ethan Walker",
                            PhoneNumber = "7890123456",
                            Status = "Non-Active",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("db1c7c95-3f0e-4c0b-91ff-bd1ecb5010ae"),
                            CreatedAt = new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2273),
                            Email = "ava@example.com",
                            Name = "Ava Hall",
                            PhoneNumber = "8901234567",
                            Status = "Active",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CRM.Api.Models.SalesOpportunity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .HasDatabaseName("IX_SalesOpportunities_CustomerId");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_SalesOpportunities_Name");

                    b.HasIndex("Status")
                        .HasDatabaseName("IX_SalesOpportunities_Status");

                    b.ToTable("sales_opportunity", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("4a69bd10-c44c-4b78-92f0-8c3c548fe60e"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("c3d8905a-6f12-4f4e-a0d3-74a14d4c7bc4"),
                            Name = "Opportunity 1",
                            Status = "New",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("b7e76f0b-d97c-42e0-bccc-665c74064c62"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("2b80ae8a-8a09-4f8f-b5c8-cb5280eb7a5e"),
                            Name = "Opportunity 2",
                            Status = "Closed Won",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("9f0dc78e-3c84-4b89-a4e5-41ef0e59f58e"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("7f6c67f5-6f0b-4e5e-9ed9-b58f7cf6010e"),
                            Name = "Opportunity 3",
                            Status = "Lost",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("0a844944-93e9-4d79-a0ef-eaa99d1e13d7"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("ef47f567-2b2c-4d8d-9c51-66369c0f9fa1"),
                            Name = "Opportunity 4",
                            Status = "New",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("8c7e72b5-3b58-4f80-bc77-74a52c6e3ff3"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("cd43a7a6-3d9f-471e-81ae-ecc6edcb8ab1"),
                            Name = "Opportunity 5",
                            Status = "Closed Won",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("e67cbbfc-7320-4574-bcc1-b5913b0b14ef"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("abf58660-f942-4632-b76d-93174ee7ac41"),
                            Name = "Opportunity 6",
                            Status = "New",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("654f7b73-c502-49b1-95d3-68f3d7c9d2e0"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("f748b8be-82f7-4ec0-86b7-8a5e35e94727"),
                            Name = "Opportunity 7",
                            Status = "Closed Lost",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("66db1a29-c72c-4878-b89c-b1d4a949c124"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("3e8efcc8-07fa-4f53-9477-e3eaf34b98ed"),
                            Name = "Opportunity 8",
                            Status = "New",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("1200f76e-98f4-4ac1-a83f-efc3743fc6a2"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("e0b94f78-2257-4964-a20c-6bc5149d1ae2"),
                            Name = "Opportunity 9",
                            Status = "Closed Won",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("7729cdb7-10b6-4f71-b3ef-3e4f12e0be6b"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("efcfd745-6b30-4b41-8a6f-e779baf53175"),
                            Name = "Opportunity 10",
                            Status = "New",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("ff562ca5-e81b-45a7-90e8-54cde1c5da68"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("3c1c68e1-847f-4059-b9f8-184f92300959"),
                            Name = "Opportunity 11",
                            Status = "Closed Won",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("e9792be3-9b36-4c41-b0e5-2c8d6fc028e4"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("7328f51c-5e1b-4b57-9d64-b4817d4939d5"),
                            Name = "Opportunity 12",
                            Status = "New",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("dd90b460-65e5-403e-9b52-6b88f3f0542a"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("3dfb1384-f037-41da-b84e-4d78fd67b13b"),
                            Name = "Opportunity 13",
                            Status = "Lost",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("b04c3a47-672f-44c3-bf7f-f4f80be417cf"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("63b2c62b-f405-4f0e-8a26-b5896fdcc10d"),
                            Name = "Opportunity 14",
                            Status = "New",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("1b1cbf8c-14de-433c-bfd2-18665c0d8fd0"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("70f028c5-fd6c-4a76-87f4-456c1aefb4e3"),
                            Name = "Opportunity 15",
                            Status = "Closed Won",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("0d03c8bc-59c2-4fc4-b1a5-58fd2ff98f0e"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("31c8c8b8-d3fa-44a2-b4d2-7c85ed57453a"),
                            Name = "Opportunity 16",
                            Status = "Closed Lost",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("b65c049f-b1bb-49c9-9b4e-bfa9535da204"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("29bdb80b-1768-4eeb-83e7-5ed94c7755d4"),
                            Name = "Opportunity 17",
                            Status = "New",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("d14efde3-b5d0-4f74-99d1-94f4f3aa2bb1"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("e4eae6cb-79ed-41e1-b075-1db5a38b9647"),
                            Name = "Opportunity 18",
                            Status = "New",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("37b8ed83-ec52-46e6-9d58-688f0ee87ad7"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("a2c7e550-bd9b-40fc-8b62-01c6270e18be"),
                            Name = "Opportunity 19",
                            Status = "Closed Won",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("fc21f384-fb79-4f4e-bf85-053b67e76b78"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = new Guid("db1c7c95-3f0e-4c0b-91ff-bd1ecb5010ae"),
                            Name = "Opportunity 20",
                            Status = "New",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CRM.Api.Models.SalesOpportunity", b =>
                {
                    b.HasOne("CRM.Api.Models.Customer", "Customer")
                        .WithMany("SalesOpportunities")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CRM.Api.Models.Customer", b =>
                {
                    b.Navigation("SalesOpportunities");
                });
#pragma warning restore 612, 618
        }
    }
}
