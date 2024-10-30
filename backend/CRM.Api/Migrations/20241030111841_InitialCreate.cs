using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sales_opportunity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_opportunity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales_opportunity_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "customer",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "PhoneNumber", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("29bdb80b-1768-4eeb-83e7-5ed94c7755d4"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2267), "sophia@example.com", "Sophia Hernandez", "5678901234", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2b80ae8a-8a09-4f8f-b5c8-cb5280eb7a5e"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2234), "jane@example.com", "Jane Smith", "0987654321", "Lead", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("31c8c8b8-d3fa-44a2-b4d2-7c85ed57453a"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2265), "olivia@example.com", "Olivia Martinez", "4567890123", "Non-Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3c1c68e1-847f-4059-b9f8-184f92300959"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2256), "isabella@example.com", "Isabella Moore", "8908908901", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3dfb1384-f037-41da-b84e-4d78fd67b13b"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2260), "liam@example.com", "Liam Anderson", "9876543210", "Non-Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3e8efcc8-07fa-4f53-9477-e3eaf34b98ed"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2251), "frank@example.com", "Frank Wilson", "7897897890", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("63b2c62b-f405-4f0e-8a26-b5896fdcc10d"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2262), "mia@example.com", "Mia Thomas", "6543210987", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("70f028c5-fd6c-4a76-87f4-456c1aefb4e3"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2263), "noah@example.com", "Noah Garcia", "3456789012", "Lead", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7328f51c-5e1b-4b57-9d64-b4817d4939d5"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2258), "jack@example.com", "Jack Taylor", "1231234567", "Lead", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7f6c67f5-6f0b-4e5e-9ed9-b58f7cf6010e"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2237), "bob@example.com", "Bob Johnson", "1112223333", "Non-Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a2c7e550-bd9b-40fc-8b62-01c6270e18be"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2270), "ethan@example.com", "Ethan Walker", "7890123456", "Non-Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("abf58660-f942-4632-b76d-93174ee7ac41"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2242), "david@example.com", "David Miller", "1231231234", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c3d8905a-6f12-4f4e-a0d3-74a14d4c7bc4"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2229), "john@example.com", "John Doe", "1234567890", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd43a7a6-3d9f-471e-81ae-ecc6edcb8ab1"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2240), "charlie@example.com", "Charlie Brown", "7778889999", "Lead", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("db1c7c95-3f0e-4c0b-91ff-bd1ecb5010ae"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2273), "ava@example.com", "Ava Hall", "8901234567", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e0b94f78-2257-4964-a20c-6bc5149d1ae2"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2253), "grace@example.com", "Grace Lee", "2342342345", "Lead", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e4eae6cb-79ed-41e1-b075-1db5a38b9647"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2269), "lucas@example.com", "Lucas Lopez", "6789012345", "Lead", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ef47f567-2b2c-4d8d-9c51-66369c0f9fa1"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2239), "alice@example.com", "Alice Williams", "4445556666", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("efcfd745-6b30-4b41-8a6f-e779baf53175"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2254), "henry@example.com", "Henry Thomas", "5675675678", "Non-Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f748b8be-82f7-4ec0-86b7-8a5e35e94727"), new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2249), "emma@example.com", "Emma Davis", "4564564567", "Non-Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "sales_opportunity",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0a844944-93e9-4d79-a0ef-eaa99d1e13d7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ef47f567-2b2c-4d8d-9c51-66369c0f9fa1"), "Opportunity 4", "New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0d03c8bc-59c2-4fc4-b1a5-58fd2ff98f0e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("31c8c8b8-d3fa-44a2-b4d2-7c85ed57453a"), "Opportunity 16", "Closed Lost", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1200f76e-98f4-4ac1-a83f-efc3743fc6a2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e0b94f78-2257-4964-a20c-6bc5149d1ae2"), "Opportunity 9", "Closed Won", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1b1cbf8c-14de-433c-bfd2-18665c0d8fd0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("70f028c5-fd6c-4a76-87f4-456c1aefb4e3"), "Opportunity 15", "Closed Won", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("37b8ed83-ec52-46e6-9d58-688f0ee87ad7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a2c7e550-bd9b-40fc-8b62-01c6270e18be"), "Opportunity 19", "Closed Won", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4a69bd10-c44c-4b78-92f0-8c3c548fe60e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c3d8905a-6f12-4f4e-a0d3-74a14d4c7bc4"), "Opportunity 1", "New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("654f7b73-c502-49b1-95d3-68f3d7c9d2e0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f748b8be-82f7-4ec0-86b7-8a5e35e94727"), "Opportunity 7", "Closed Lost", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("66db1a29-c72c-4878-b89c-b1d4a949c124"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e8efcc8-07fa-4f53-9477-e3eaf34b98ed"), "Opportunity 8", "New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7729cdb7-10b6-4f71-b3ef-3e4f12e0be6b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("efcfd745-6b30-4b41-8a6f-e779baf53175"), "Opportunity 10", "New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8c7e72b5-3b58-4f80-bc77-74a52c6e3ff3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cd43a7a6-3d9f-471e-81ae-ecc6edcb8ab1"), "Opportunity 5", "Closed Won", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f0dc78e-3c84-4b89-a4e5-41ef0e59f58e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7f6c67f5-6f0b-4e5e-9ed9-b58f7cf6010e"), "Opportunity 3", "Lost", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b04c3a47-672f-44c3-bf7f-f4f80be417cf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("63b2c62b-f405-4f0e-8a26-b5896fdcc10d"), "Opportunity 14", "New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b65c049f-b1bb-49c9-9b4e-bfa9535da204"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("29bdb80b-1768-4eeb-83e7-5ed94c7755d4"), "Opportunity 17", "New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b7e76f0b-d97c-42e0-bccc-665c74064c62"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2b80ae8a-8a09-4f8f-b5c8-cb5280eb7a5e"), "Opportunity 2", "Closed Won", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d14efde3-b5d0-4f74-99d1-94f4f3aa2bb1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e4eae6cb-79ed-41e1-b075-1db5a38b9647"), "Opportunity 18", "New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dd90b460-65e5-403e-9b52-6b88f3f0542a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3dfb1384-f037-41da-b84e-4d78fd67b13b"), "Opportunity 13", "Lost", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e67cbbfc-7320-4574-bcc1-b5913b0b14ef"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("abf58660-f942-4632-b76d-93174ee7ac41"), "Opportunity 6", "New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e9792be3-9b36-4c41-b0e5-2c8d6fc028e4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7328f51c-5e1b-4b57-9d64-b4817d4939d5"), "Opportunity 12", "New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fc21f384-fb79-4f4e-bf85-053b67e76b78"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("db1c7c95-3f0e-4c0b-91ff-bd1ecb5010ae"), "Opportunity 20", "New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ff562ca5-e81b-45a7-90e8-54cde1c5da68"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3c1c68e1-847f-4059-b9f8-184f92300959"), "Opportunity 11", "Closed Won", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "customer",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Name",
                table: "customer",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Status",
                table: "customer",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOpportunities_CustomerId",
                table: "sales_opportunity",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOpportunities_Name",
                table: "sales_opportunity",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOpportunities_Status",
                table: "sales_opportunity",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sales_opportunity");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
