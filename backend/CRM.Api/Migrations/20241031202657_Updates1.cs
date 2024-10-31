using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM.Api.Migrations
{
    /// <inheritdoc />
    public partial class Updates1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Email",
                table: "customer");

            migrationBuilder.DeleteData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("0d03c8bc-59c2-4fc4-b1a5-58fd2ff98f0e"));

            migrationBuilder.DeleteData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("1b1cbf8c-14de-433c-bfd2-18665c0d8fd0"));

            migrationBuilder.DeleteData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("37b8ed83-ec52-46e6-9d58-688f0ee87ad7"));

            migrationBuilder.DeleteData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("b04c3a47-672f-44c3-bf7f-f4f80be417cf"));

            migrationBuilder.DeleteData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("b65c049f-b1bb-49c9-9b4e-bfa9535da204"));

            migrationBuilder.DeleteData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("d14efde3-b5d0-4f74-99d1-94f4f3aa2bb1"));

            migrationBuilder.DeleteData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("dd90b460-65e5-403e-9b52-6b88f3f0542a"));

            migrationBuilder.DeleteData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("e9792be3-9b36-4c41-b0e5-2c8d6fc028e4"));

            migrationBuilder.DeleteData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("fc21f384-fb79-4f4e-bf85-053b67e76b78"));

            migrationBuilder.DeleteData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("ff562ca5-e81b-45a7-90e8-54cde1c5da68"));

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("29bdb80b-1768-4eeb-83e7-5ed94c7755d4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3984), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3984) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("2b80ae8a-8a09-4f8f-b5c8-cb5280eb7a5e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3958), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3958) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("31c8c8b8-d3fa-44a2-b4d2-7c85ed57453a"),
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3982), "Non Active", new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3982) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("3c1c68e1-847f-4059-b9f8-184f92300959"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3974), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3974) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("3dfb1384-f037-41da-b84e-4d78fd67b13b"),
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3977), "Non Active", new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3978) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("3e8efcc8-07fa-4f53-9477-e3eaf34b98ed"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3968), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3968) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("63b2c62b-f405-4f0e-8a26-b5896fdcc10d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3979), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3979) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("70f028c5-fd6c-4a76-87f4-456c1aefb4e3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3980), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3981) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("7328f51c-5e1b-4b57-9d64-b4817d4939d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3975), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3976) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("7f6c67f5-6f0b-4e5e-9ed9-b58f7cf6010e"),
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3960), "Non Active", new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3960) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("a2c7e550-bd9b-40fc-8b62-01c6270e18be"),
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3987), "Non Active", new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3988) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("abf58660-f942-4632-b76d-93174ee7ac41"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3965), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3965) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("c3d8905a-6f12-4f4e-a0d3-74a14d4c7bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3954), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3956) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("cd43a7a6-3d9f-471e-81ae-ecc6edcb8ab1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3963), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3964) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("db1c7c95-3f0e-4c0b-91ff-bd1ecb5010ae"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3989), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3989) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("e0b94f78-2257-4964-a20c-6bc5149d1ae2"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3970), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3970) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("e4eae6cb-79ed-41e1-b075-1db5a38b9647"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3986), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3986) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("ef47f567-2b2c-4d8d-9c51-66369c0f9fa1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3962), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3962) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("efcfd745-6b30-4b41-8a6f-e779baf53175"),
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3972), "Non Active", new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3973) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("f748b8be-82f7-4ec0-86b7-8a5e35e94727"),
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3966), "Non Active", new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(3967) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("0a844944-93e9-4d79-a0ef-eaa99d1e13d7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4111), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4111) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("1200f76e-98f4-4ac1-a83f-efc3743fc6a2"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4118), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4118) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("4a69bd10-c44c-4b78-92f0-8c3c548fe60e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4105), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4106) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("654f7b73-c502-49b1-95d3-68f3d7c9d2e0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4115), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4115) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("66db1a29-c72c-4878-b89c-b1d4a949c124"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4117), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4117) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("7729cdb7-10b6-4f71-b3ef-3e4f12e0be6b"),
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4119), "Closed Won", new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4120) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("8c7e72b5-3b58-4f80-bc77-74a52c6e3ff3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4112), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4113) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("9f0dc78e-3c84-4b89-a4e5-41ef0e59f58e"),
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4109), "Closed Lost", new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4109) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("b7e76f0b-d97c-42e0-bccc-665c74064c62"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4107), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4108) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("e67cbbfc-7320-4574-bcc1-b5913b0b14ef"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4114), new DateTime(2024, 10, 31, 20, 26, 57, 293, DateTimeKind.Utc).AddTicks(4114) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("29bdb80b-1768-4eeb-83e7-5ed94c7755d4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2267), new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9049) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("2b80ae8a-8a09-4f8f-b5c8-cb5280eb7a5e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2234), new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9010) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("31c8c8b8-d3fa-44a2-b4d2-7c85ed57453a"),
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2265), "Non-Active", new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9048) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("3c1c68e1-847f-4059-b9f8-184f92300959"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2256), new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9041) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("3dfb1384-f037-41da-b84e-4d78fd67b13b"),
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2260), "Non-Active", new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9044) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("3e8efcc8-07fa-4f53-9477-e3eaf34b98ed"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2251), new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("63b2c62b-f405-4f0e-8a26-b5896fdcc10d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2262), new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9045) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("70f028c5-fd6c-4a76-87f4-456c1aefb4e3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2263), new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9047) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("7328f51c-5e1b-4b57-9d64-b4817d4939d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2258), new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9043) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("7f6c67f5-6f0b-4e5e-9ed9-b58f7cf6010e"),
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2237), "Non-Active", new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9011) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("a2c7e550-bd9b-40fc-8b62-01c6270e18be"),
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2270), "Non-Active", new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9064) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("abf58660-f942-4632-b76d-93174ee7ac41"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2242), new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9015) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("c3d8905a-6f12-4f4e-a0d3-74a14d4c7bc4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2229), new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9006) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("cd43a7a6-3d9f-471e-81ae-ecc6edcb8ab1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2240), new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9014) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("db1c7c95-3f0e-4c0b-91ff-bd1ecb5010ae"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2273), new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9066) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("e0b94f78-2257-4964-a20c-6bc5149d1ae2"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2253), new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9039) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("e4eae6cb-79ed-41e1-b075-1db5a38b9647"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2269), new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9062) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("ef47f567-2b2c-4d8d-9c51-66369c0f9fa1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2239), new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9013) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("efcfd745-6b30-4b41-8a6f-e779baf53175"),
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2254), "Non-Active", new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9040) });

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "Id",
                keyValue: new Guid("f748b8be-82f7-4ec0-86b7-8a5e35e94727"),
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 11, 18, 41, 270, DateTimeKind.Utc).AddTicks(2249), "Non-Active", new DateTime(2024, 10, 31, 20, 26, 47, 859, DateTimeKind.Utc).AddTicks(9017) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("0a844944-93e9-4d79-a0ef-eaa99d1e13d7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3338), new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3338) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("1200f76e-98f4-4ac1-a83f-efc3743fc6a2"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3402), new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3409) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("4a69bd10-c44c-4b78-92f0-8c3c548fe60e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3317), new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3323) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("654f7b73-c502-49b1-95d3-68f3d7c9d2e0"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3397), new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3398) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("66db1a29-c72c-4878-b89c-b1d4a949c124"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3400), new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3401) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("7729cdb7-10b6-4f71-b3ef-3e4f12e0be6b"),
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3410), "New", new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3411) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("8c7e72b5-3b58-4f80-bc77-74a52c6e3ff3"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3340), new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3348) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("9f0dc78e-3c84-4b89-a4e5-41ef0e59f58e"),
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3335), "Lost", new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3337) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("b7e76f0b-d97c-42e0-bccc-665c74064c62"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3332), new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3333) });

            migrationBuilder.UpdateData(
                table: "sales_opportunity",
                keyColumn: "Id",
                keyValue: new Guid("e67cbbfc-7320-4574-bcc1-b5913b0b14ef"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3395), new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3396) });

            migrationBuilder.InsertData(
                table: "sales_opportunity",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0d03c8bc-59c2-4fc4-b1a5-58fd2ff98f0e"), new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3431), new Guid("31c8c8b8-d3fa-44a2-b4d2-7c85ed57453a"), "Opportunity 16", "Closed Lost", new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3431) },
                    { new Guid("1b1cbf8c-14de-433c-bfd2-18665c0d8fd0"), new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3423), new Guid("70f028c5-fd6c-4a76-87f4-456c1aefb4e3"), "Opportunity 15", "Closed Won", new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3426) },
                    { new Guid("37b8ed83-ec52-46e6-9d58-688f0ee87ad7"), new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3455), new Guid("a2c7e550-bd9b-40fc-8b62-01c6270e18be"), "Opportunity 19", "Closed Won", new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3456) },
                    { new Guid("b04c3a47-672f-44c3-bf7f-f4f80be417cf"), new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3422), new Guid("63b2c62b-f405-4f0e-8a26-b5896fdcc10d"), "Opportunity 14", "New", new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3422) },
                    { new Guid("b65c049f-b1bb-49c9-9b4e-bfa9535da204"), new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3436), new Guid("29bdb80b-1768-4eeb-83e7-5ed94c7755d4"), "Opportunity 17", "New", new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3452) },
                    { new Guid("d14efde3-b5d0-4f74-99d1-94f4f3aa2bb1"), new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3453), new Guid("e4eae6cb-79ed-41e1-b075-1db5a38b9647"), "Opportunity 18", "New", new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3454) },
                    { new Guid("dd90b460-65e5-403e-9b52-6b88f3f0542a"), new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3420), new Guid("3dfb1384-f037-41da-b84e-4d78fd67b13b"), "Opportunity 13", "Lost", new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3420) },
                    { new Guid("e9792be3-9b36-4c41-b0e5-2c8d6fc028e4"), new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3418), new Guid("7328f51c-5e1b-4b57-9d64-b4817d4939d5"), "Opportunity 12", "New", new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3419) },
                    { new Guid("fc21f384-fb79-4f4e-bf85-053b67e76b78"), new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3457), new Guid("db1c7c95-3f0e-4c0b-91ff-bd1ecb5010ae"), "Opportunity 20", "New", new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3457) },
                    { new Guid("ff562ca5-e81b-45a7-90e8-54cde1c5da68"), new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3416), new Guid("3c1c68e1-847f-4059-b9f8-184f92300959"), "Opportunity 11", "Closed Won", new DateTime(2024, 10, 31, 20, 26, 47, 862, DateTimeKind.Utc).AddTicks(3417) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "customer",
                column: "Email");
        }
    }
}
