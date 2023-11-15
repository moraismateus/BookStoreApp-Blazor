using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUserAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4853b38b-6296-49e1-939a-6a25a93b01f2", null, "User", "USER" },
                    { "603a37dd-4a09-4633-af41-017743742dc0", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "aab32168-1ee4-4e04-90b5-08f770e09317", 0, "b7dfe96b-746b-4529-afe6-dc29f2496ce7", "admin@bookstrore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAIAAYagAAAAENnCfAClFz0GF24pU5Nslp7TTwu0ldr3uwXXeI7X5dBYywy9BdCBCOyI6p0Mb29BnA==", null, false, "a3e61c30-d5b8-484d-a7c0-462ad6bca2e5", false, "admin@bookstrore.com" },
                    { "f48eec2e-c3ec-4b32-bd93-ad88da2b87e2", 0, "5411e1cb-acca-4118-91c7-bac806039e1f", "user@bookstrore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEKK8mV1P/W6El4AWQSGpp66bXWOeG89hoJuq5DTd9jrxUgGwLiC1J1fbs07GMmrVSQ==", null, false, "74f72af2-7247-4d09-956f-ab1af35f3b09", false, "user@bookstrore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "603a37dd-4a09-4633-af41-017743742dc0", "aab32168-1ee4-4e04-90b5-08f770e09317" },
                    { "4853b38b-6296-49e1-939a-6a25a93b01f2", "f48eec2e-c3ec-4b32-bd93-ad88da2b87e2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "603a37dd-4a09-4633-af41-017743742dc0", "aab32168-1ee4-4e04-90b5-08f770e09317" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4853b38b-6296-49e1-939a-6a25a93b01f2", "f48eec2e-c3ec-4b32-bd93-ad88da2b87e2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4853b38b-6296-49e1-939a-6a25a93b01f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "603a37dd-4a09-4633-af41-017743742dc0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aab32168-1ee4-4e04-90b5-08f770e09317");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f48eec2e-c3ec-4b32-bd93-ad88da2b87e2");
        }
    }
}
