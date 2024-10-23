using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GripOnMash.Migrations
{
    /// <inheritdoc />
    public partial class RinominazioneCodiceRandomIntoCodiceMedico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "3aa43883-0392-4eeb-a6db-a78d4267f04f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "46dafb0c-f49c-4d75-b2f8-4eb3183c546a" });

            migrationBuilder.DeleteData(
                table: "InternalUserRole",
                keyColumns: new[] { "InternalUserId", "RoleId" },
                keyValues: new object[] { new Guid("4983227c-0272-4078-86b5-84067653d162"), "fe232d35-f62d-407f-995b-1934d38d96cc" });

            migrationBuilder.DeleteData(
                table: "InternalUserRole",
                keyColumns: new[] { "InternalUserId", "RoleId" },
                keyValues: new object[] { new Guid("8b68bdde-bb67-4918-b84a-cdf1adde281e"), "fe232d35-f62d-407f-995b-1934d38d96cc" });

            migrationBuilder.DeleteData(
                table: "InternalUserRole",
                keyColumns: new[] { "InternalUserId", "RoleId" },
                keyValues: new object[] { new Guid("ef6fd07e-0ca9-43d9-90d2-29bdeb2e9178"), "fe232d35-f62d-407f-995b-1934d38d96cc" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3aa43883-0392-4eeb-a6db-a78d4267f04f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46dafb0c-f49c-4d75-b2f8-4eb3183c546a");

            migrationBuilder.DeleteData(
                table: "InternalUser",
                keyColumn: "Id",
                keyValue: new Guid("4983227c-0272-4078-86b5-84067653d162"));

            migrationBuilder.DeleteData(
                table: "InternalUser",
                keyColumn: "Id",
                keyValue: new Guid("8b68bdde-bb67-4918-b84a-cdf1adde281e"));

            migrationBuilder.DeleteData(
                table: "InternalUser",
                keyColumn: "Id",
                keyValue: new Guid("ef6fd07e-0ca9-43d9-90d2-29bdeb2e9178"));

            migrationBuilder.RenameColumn(
                name: "CodiceRandomico",
                table: "AspNetUsers",
                newName: "CodiceMedico");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CodiceMedico", "CodiceOtp", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "ab80eb4f-6496-46a2-bebd-ab6f26b56278", 0, "A1B2", "CodiceOtpSilveriMarco", "Silveri", "f87ba500-74cb-400e-b2bc-d404faf8856f", "medicobase1@gmail.com", true, false, true, null, "Marco", "MEDICOBASE1@GMAIL.COM", "MEDICOBASE1_UNICO", "AQAAAAIAAYagAAAAENyGbETOsyY2AtZJDaz/GdhRPYiW/fOMjPvKFQwh2+56KJR1poyDqZFRS9UVmviwOg==", null, false, "d6893e41-4c85-4138-8d85-eec29e115207", false, "medicoBase1_unico" },
                    { "b6439946-fd37-4c3d-b914-48b45649ff7d", 0, "C3D4", "CodiceOtpFrancescoGentile", "Gentile", "fee75679-a35e-4f21-b1cb-82deb4fb3dc1", "medicobase2@gmail.com", true, false, true, null, "Francesco", "MEDICOBASE2@GMAIL.COM", "MEDICOBASE2_UNICO", "AQAAAAIAAYagAAAAENWYrRv2C+YcZzf93axxWtDDt28IHT6jISxWkJzT0Ksz29YA1f9mFHsSQ3zw7E4eCw==", null, false, "3eb63380-20b1-465a-938a-2e3818cc9b77", false, "medicoBase2_unico" }
                });

            migrationBuilder.InsertData(
                table: "InternalUser",
                columns: new[] { "Id", "Cognome", "IsEnabled", "Matricola", "Nome" },
                values: new object[,]
                {
                    { new Guid("0652526e-3fa0-47b8-9f6a-c6c45444919e"), "Rossi", true, "sb004194", "Mario" },
                    { new Guid("3eb33dd3-c69d-48e1-bca5-7e7ccb6efcee"), "Silveri", true, "sb004193", "Marco" },
                    { new Guid("d1a2001a-be5f-48f0-944d-e3556773beb1"), "Picchi", true, "00665539", "Daniele" }
                });

            migrationBuilder.UpdateData(
                table: "MedicoBaseAnagrafica",
                keyColumn: "MedicoBaseAnagraficaId",
                keyValue: 1,
                column: "IdentityId",
                value: "ab80eb4f-6496-46a2-bebd-ab6f26b56278");

            migrationBuilder.UpdateData(
                table: "MedicoBaseAnagrafica",
                keyColumn: "MedicoBaseAnagraficaId",
                keyValue: 2,
                column: "IdentityId",
                value: "b6439946-fd37-4c3d-b914-48b45649ff7d");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "ab80eb4f-6496-46a2-bebd-ab6f26b56278" },
                    { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "b6439946-fd37-4c3d-b914-48b45649ff7d" }
                });

            migrationBuilder.InsertData(
                table: "InternalUserRole",
                columns: new[] { "InternalUserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("0652526e-3fa0-47b8-9f6a-c6c45444919e"), "fe232d35-f62d-407f-995b-1934d38d96cc" },
                    { new Guid("3eb33dd3-c69d-48e1-bca5-7e7ccb6efcee"), "fe232d35-f62d-407f-995b-1934d38d96cc" },
                    { new Guid("d1a2001a-be5f-48f0-944d-e3556773beb1"), "fe232d35-f62d-407f-995b-1934d38d96cc" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "ab80eb4f-6496-46a2-bebd-ab6f26b56278" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "b6439946-fd37-4c3d-b914-48b45649ff7d" });

            migrationBuilder.DeleteData(
                table: "InternalUserRole",
                keyColumns: new[] { "InternalUserId", "RoleId" },
                keyValues: new object[] { new Guid("0652526e-3fa0-47b8-9f6a-c6c45444919e"), "fe232d35-f62d-407f-995b-1934d38d96cc" });

            migrationBuilder.DeleteData(
                table: "InternalUserRole",
                keyColumns: new[] { "InternalUserId", "RoleId" },
                keyValues: new object[] { new Guid("3eb33dd3-c69d-48e1-bca5-7e7ccb6efcee"), "fe232d35-f62d-407f-995b-1934d38d96cc" });

            migrationBuilder.DeleteData(
                table: "InternalUserRole",
                keyColumns: new[] { "InternalUserId", "RoleId" },
                keyValues: new object[] { new Guid("d1a2001a-be5f-48f0-944d-e3556773beb1"), "fe232d35-f62d-407f-995b-1934d38d96cc" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ab80eb4f-6496-46a2-bebd-ab6f26b56278");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6439946-fd37-4c3d-b914-48b45649ff7d");

            migrationBuilder.DeleteData(
                table: "InternalUser",
                keyColumn: "Id",
                keyValue: new Guid("0652526e-3fa0-47b8-9f6a-c6c45444919e"));

            migrationBuilder.DeleteData(
                table: "InternalUser",
                keyColumn: "Id",
                keyValue: new Guid("3eb33dd3-c69d-48e1-bca5-7e7ccb6efcee"));

            migrationBuilder.DeleteData(
                table: "InternalUser",
                keyColumn: "Id",
                keyValue: new Guid("d1a2001a-be5f-48f0-944d-e3556773beb1"));

            migrationBuilder.RenameColumn(
                name: "CodiceMedico",
                table: "AspNetUsers",
                newName: "CodiceRandomico");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CodiceOtp", "CodiceRandomico", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3aa43883-0392-4eeb-a6db-a78d4267f04f", 0, "CodiceOtpFrancescoGentile", "C3D4", "Gentile", "7ebf28fe-9cd0-4614-8d41-2ede037f3e03", "medicobase2@gmail.com", true, false, true, null, "Francesco", "MEDICOBASE2@GMAIL.COM", "MEDICOBASE2_UNICO", "AQAAAAIAAYagAAAAEITWZfArf3zYaqG2pqwwGpMvLnm3dFJvMvFlqQJsKhqicXplqpU4uvrtsNnj/vXUjA==", null, false, "6830e6ab-8c1a-4702-ad25-70b547878ae3", false, "medicoBase2_unico" },
                    { "46dafb0c-f49c-4d75-b2f8-4eb3183c546a", 0, "CodiceOtpSilveriMarco", "A1B2", "Silveri", "fd293dfc-18cd-4783-b12d-09ef49aa7919", "medicobase1@gmail.com", true, false, true, null, "Marco", "MEDICOBASE1@GMAIL.COM", "MEDICOBASE1_UNICO", "AQAAAAIAAYagAAAAEDUyMHFdOvoBzhsPI5sQkGYwJ0yFgcS4QJTw8m/GL0OmSl1S6op4BdNxJD7RYgru7A==", null, false, "330ea23c-dfdb-487f-ae64-cfc5bc263ed9", false, "medicoBase1_unico" }
                });

            migrationBuilder.InsertData(
                table: "InternalUser",
                columns: new[] { "Id", "Cognome", "IsEnabled", "Matricola", "Nome" },
                values: new object[,]
                {
                    { new Guid("4983227c-0272-4078-86b5-84067653d162"), "Silveri", true, "sb004193", "Marco" },
                    { new Guid("8b68bdde-bb67-4918-b84a-cdf1adde281e"), "Rossi", true, "sb004194", "Mario" },
                    { new Guid("ef6fd07e-0ca9-43d9-90d2-29bdeb2e9178"), "Picchi", true, "00665539", "Daniele" }
                });

            migrationBuilder.UpdateData(
                table: "MedicoBaseAnagrafica",
                keyColumn: "MedicoBaseAnagraficaId",
                keyValue: 1,
                column: "IdentityId",
                value: "46dafb0c-f49c-4d75-b2f8-4eb3183c546a");

            migrationBuilder.UpdateData(
                table: "MedicoBaseAnagrafica",
                keyColumn: "MedicoBaseAnagraficaId",
                keyValue: 2,
                column: "IdentityId",
                value: "3aa43883-0392-4eeb-a6db-a78d4267f04f");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "3aa43883-0392-4eeb-a6db-a78d4267f04f" },
                    { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "46dafb0c-f49c-4d75-b2f8-4eb3183c546a" }
                });

            migrationBuilder.InsertData(
                table: "InternalUserRole",
                columns: new[] { "InternalUserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("4983227c-0272-4078-86b5-84067653d162"), "fe232d35-f62d-407f-995b-1934d38d96cc" },
                    { new Guid("8b68bdde-bb67-4918-b84a-cdf1adde281e"), "fe232d35-f62d-407f-995b-1934d38d96cc" },
                    { new Guid("ef6fd07e-0ca9-43d9-90d2-29bdeb2e9178"), "fe232d35-f62d-407f-995b-1934d38d96cc" }
                });
        }
    }
}
