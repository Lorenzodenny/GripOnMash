using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GripOnMash.Migrations
{
    /// <inheritdoc />
    public partial class SeedRuoli : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", null, "User", "USER" },
                    { "fe232d35-f62d-407f-995b-1934d38d96cc", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "447b3ca6-bd0b-4e83-baf9-2de7069c10c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe232d35-f62d-407f-995b-1934d38d96cc");
        }
    }
}
