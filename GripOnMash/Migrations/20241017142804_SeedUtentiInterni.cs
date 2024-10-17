using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GripOnMash.Migrations
{
    /// <inheritdoc />
    public partial class SeedUtentiInterni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InternalUser",
                columns: new[] { "Id", "Cognome", "IsEnabled", "Matricola", "Nome" },
                values: new object[,]
                {
                    { new Guid("1107cdf8-0255-4d21-b56a-67061a7a90cc"), "Picchi", true, "00665539", "Daniele" },
                    { new Guid("57210e02-e035-4219-846a-759d12ba9f3b"), "Silveri", true, "sb004193", "Marco" },
                    { new Guid("5ea5dc57-5013-41a1-9a33-24253f3e5910"), "Rossi", true, "sb004194", "Mario" }
                });

            migrationBuilder.InsertData(
                table: "InternalUserRole",
                columns: new[] { "InternalUserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("1107cdf8-0255-4d21-b56a-67061a7a90cc"), "fe232d35-f62d-407f-995b-1934d38d96cc" },
                    { new Guid("57210e02-e035-4219-846a-759d12ba9f3b"), "fe232d35-f62d-407f-995b-1934d38d96cc" },
                    { new Guid("5ea5dc57-5013-41a1-9a33-24253f3e5910"), "fe232d35-f62d-407f-995b-1934d38d96cc" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InternalUserRole",
                keyColumns: new[] { "InternalUserId", "RoleId" },
                keyValues: new object[] { new Guid("1107cdf8-0255-4d21-b56a-67061a7a90cc"), "fe232d35-f62d-407f-995b-1934d38d96cc" });

            migrationBuilder.DeleteData(
                table: "InternalUserRole",
                keyColumns: new[] { "InternalUserId", "RoleId" },
                keyValues: new object[] { new Guid("57210e02-e035-4219-846a-759d12ba9f3b"), "fe232d35-f62d-407f-995b-1934d38d96cc" });

            migrationBuilder.DeleteData(
                table: "InternalUserRole",
                keyColumns: new[] { "InternalUserId", "RoleId" },
                keyValues: new object[] { new Guid("5ea5dc57-5013-41a1-9a33-24253f3e5910"), "fe232d35-f62d-407f-995b-1934d38d96cc" });

            migrationBuilder.DeleteData(
                table: "InternalUser",
                keyColumn: "Id",
                keyValue: new Guid("1107cdf8-0255-4d21-b56a-67061a7a90cc"));

            migrationBuilder.DeleteData(
                table: "InternalUser",
                keyColumn: "Id",
                keyValue: new Guid("57210e02-e035-4219-846a-759d12ba9f3b"));

            migrationBuilder.DeleteData(
                table: "InternalUser",
                keyColumn: "Id",
                keyValue: new Guid("5ea5dc57-5013-41a1-9a33-24253f3e5910"));
        }
    }
}
