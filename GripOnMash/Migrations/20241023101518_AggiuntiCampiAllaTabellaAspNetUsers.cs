using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GripOnMash.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntiCampiAllaTabellaAspNetUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "11d6746e-b41f-49b8-bed8-d01a496d64f0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "c13cdd33-ed45-477c-89e0-deb2d3bc54cc" });

            migrationBuilder.DeleteData(
                table: "InternalUserRole",
                keyColumns: new[] { "InternalUserId", "RoleId" },
                keyValues: new object[] { new Guid("0273e6a7-702a-48e9-8296-4f3a83509c5b"), "fe232d35-f62d-407f-995b-1934d38d96cc" });

            migrationBuilder.DeleteData(
                table: "InternalUserRole",
                keyColumns: new[] { "InternalUserId", "RoleId" },
                keyValues: new object[] { new Guid("7347bf3c-0ab6-4f66-b8ee-4bfe41f54dcc"), "fe232d35-f62d-407f-995b-1934d38d96cc" });

            migrationBuilder.DeleteData(
                table: "InternalUserRole",
                keyColumns: new[] { "InternalUserId", "RoleId" },
                keyValues: new object[] { new Guid("dff2ddeb-9e4e-4120-b699-b1d4157fb39d"), "fe232d35-f62d-407f-995b-1934d38d96cc" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11d6746e-b41f-49b8-bed8-d01a496d64f0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c13cdd33-ed45-477c-89e0-deb2d3bc54cc");

            migrationBuilder.DeleteData(
                table: "InternalUser",
                keyColumn: "Id",
                keyValue: new Guid("0273e6a7-702a-48e9-8296-4f3a83509c5b"));

            migrationBuilder.DeleteData(
                table: "InternalUser",
                keyColumn: "Id",
                keyValue: new Guid("7347bf3c-0ab6-4f66-b8ee-4bfe41f54dcc"));

            migrationBuilder.DeleteData(
                table: "InternalUser",
                keyColumn: "Id",
                keyValue: new Guid("dff2ddeb-9e4e-4120-b699-b1d4157fb39d"));

            migrationBuilder.AddColumn<string>(
                name: "CodiceOtp",
                table: "AspNetUsers",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cognome",
                table: "AspNetUsers",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CodiceOtp", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "02c79a3f-d68a-4898-b1c1-41c41a97d874", 0, "654321", "Silveri", "f350367d-faf7-4540-9199-257715e03f6c", "medicobase1@gmail.com", true, false, true, null, "Marco", "MEDICOBASE1@GMAIL.COM", "MEDICOBASE1_UNICO", "AQAAAAIAAYagAAAAECPu92CFNaKKL9eNq7nDwdW76+p704TKSs17y9/Ccm7TL48GrojUIYwXaA4LKnPlhQ==", null, false, "759b24d0-a4f2-493b-8e97-6fffa292a7d9", false, "medicoBase1_unico" },
                    { "ea1d0d35-967d-4af0-a98c-cb32fc215e86", 0, "123654", "Gentile", "d6e94949-b3f8-441f-b67e-fe67363a9ffd", "medicobase2@gmail.com", true, false, true, null, "Francesco", "MEDICOBASE2@GMAIL.COM", "MEDICOBASE2_UNICO", "AQAAAAIAAYagAAAAEKKgji+1hS2qz0qK7arG6jhz4nDeJFNL62szqPZku+Pji9ujtem2jLifdbZjqWfrlw==", null, false, "b0ceb0d4-a7ea-4b89-8aad-f442e284bb16", false, "medicoBase2_unico" }
                });

            migrationBuilder.InsertData(
                table: "InternalUser",
                columns: new[] { "Id", "Cognome", "IsEnabled", "Matricola", "Nome" },
                values: new object[,]
                {
                    { new Guid("14276c8b-8d03-4a70-8518-198e83431fb1"), "Rossi", true, "sb004194", "Mario" },
                    { new Guid("4a9a8097-8ad3-4023-ac3d-987a4b25d1ba"), "Picchi", true, "00665539", "Daniele" },
                    { new Guid("7cfe4bd8-7aaf-46df-a692-c058b49f5741"), "Silveri", true, "sb004193", "Marco" }
                });

            migrationBuilder.UpdateData(
                table: "MedicoBaseAnagrafica",
                keyColumn: "MedicoBaseAnagraficaId",
                keyValue: 1,
                column: "IdentityId",
                value: "02c79a3f-d68a-4898-b1c1-41c41a97d874");

            migrationBuilder.UpdateData(
                table: "MedicoBaseAnagrafica",
                keyColumn: "MedicoBaseAnagraficaId",
                keyValue: 2,
                column: "IdentityId",
                value: "ea1d0d35-967d-4af0-a98c-cb32fc215e86");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "02c79a3f-d68a-4898-b1c1-41c41a97d874" },
                    { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "ea1d0d35-967d-4af0-a98c-cb32fc215e86" }
                });

            migrationBuilder.InsertData(
                table: "InternalUserRole",
                columns: new[] { "InternalUserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("14276c8b-8d03-4a70-8518-198e83431fb1"), "fe232d35-f62d-407f-995b-1934d38d96cc" },
                    { new Guid("4a9a8097-8ad3-4023-ac3d-987a4b25d1ba"), "fe232d35-f62d-407f-995b-1934d38d96cc" },
                    { new Guid("7cfe4bd8-7aaf-46df-a692-c058b49f5741"), "fe232d35-f62d-407f-995b-1934d38d96cc" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "02c79a3f-d68a-4898-b1c1-41c41a97d874" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "ea1d0d35-967d-4af0-a98c-cb32fc215e86" });

            migrationBuilder.DeleteData(
                table: "InternalUserRole",
                keyColumns: new[] { "InternalUserId", "RoleId" },
                keyValues: new object[] { new Guid("14276c8b-8d03-4a70-8518-198e83431fb1"), "fe232d35-f62d-407f-995b-1934d38d96cc" });

            migrationBuilder.DeleteData(
                table: "InternalUserRole",
                keyColumns: new[] { "InternalUserId", "RoleId" },
                keyValues: new object[] { new Guid("4a9a8097-8ad3-4023-ac3d-987a4b25d1ba"), "fe232d35-f62d-407f-995b-1934d38d96cc" });

            migrationBuilder.DeleteData(
                table: "InternalUserRole",
                keyColumns: new[] { "InternalUserId", "RoleId" },
                keyValues: new object[] { new Guid("7cfe4bd8-7aaf-46df-a692-c058b49f5741"), "fe232d35-f62d-407f-995b-1934d38d96cc" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02c79a3f-d68a-4898-b1c1-41c41a97d874");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea1d0d35-967d-4af0-a98c-cb32fc215e86");

            migrationBuilder.DeleteData(
                table: "InternalUser",
                keyColumn: "Id",
                keyValue: new Guid("14276c8b-8d03-4a70-8518-198e83431fb1"));

            migrationBuilder.DeleteData(
                table: "InternalUser",
                keyColumn: "Id",
                keyValue: new Guid("4a9a8097-8ad3-4023-ac3d-987a4b25d1ba"));

            migrationBuilder.DeleteData(
                table: "InternalUser",
                keyColumn: "Id",
                keyValue: new Guid("7cfe4bd8-7aaf-46df-a692-c058b49f5741"));

            migrationBuilder.DropColumn(
                name: "CodiceOtp",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Cognome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11d6746e-b41f-49b8-bed8-d01a496d64f0", 0, "af233b2b-7285-4dfd-ab6b-fcb8ea058ad9", "medicobase1@gmail.com", true, true, null, "MEDICOBASE1@GMAIL.COM", "MEDICOBASE1", "AQAAAAIAAYagAAAAECo0kjomf4JBihYEoK8Vray6D8PJEAZMylaeJn51kx8tY58S6CY6kS+MgL5gKCIr5w==", null, false, "160f56c4-8933-48d9-b921-f34b72010dba", false, "medicoBase1" },
                    { "c13cdd33-ed45-477c-89e0-deb2d3bc54cc", 0, "f38b96ce-e218-4b77-ac8b-3005dd62e905", "medicobase2@gmail.com", true, true, null, "MEDICOBASE2@GMAIL.COM", "MEDICOBASE2", "AQAAAAIAAYagAAAAENzuvdg+xVrY5RlKdrMcDKRK1qVr0Z5QZAkBDwUxCTWNmSEiqHM6C7Eah9Atsw+o/g==", null, false, "114f7fdb-a932-4a36-91d7-c03fc353904e", false, "medicoBase2" }
                });

            migrationBuilder.InsertData(
                table: "InternalUser",
                columns: new[] { "Id", "Cognome", "IsEnabled", "Matricola", "Nome" },
                values: new object[,]
                {
                    { new Guid("0273e6a7-702a-48e9-8296-4f3a83509c5b"), "Picchi", true, "00665539", "Daniele" },
                    { new Guid("7347bf3c-0ab6-4f66-b8ee-4bfe41f54dcc"), "Silveri", true, "sb004193", "Marco" },
                    { new Guid("dff2ddeb-9e4e-4120-b699-b1d4157fb39d"), "Rossi", true, "sb004194", "Mario" }
                });

            migrationBuilder.UpdateData(
                table: "MedicoBaseAnagrafica",
                keyColumn: "MedicoBaseAnagraficaId",
                keyValue: 1,
                column: "IdentityId",
                value: "11d6746e-b41f-49b8-bed8-d01a496d64f0");

            migrationBuilder.UpdateData(
                table: "MedicoBaseAnagrafica",
                keyColumn: "MedicoBaseAnagraficaId",
                keyValue: 2,
                column: "IdentityId",
                value: "c13cdd33-ed45-477c-89e0-deb2d3bc54cc");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "11d6746e-b41f-49b8-bed8-d01a496d64f0" },
                    { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "c13cdd33-ed45-477c-89e0-deb2d3bc54cc" }
                });

            migrationBuilder.InsertData(
                table: "InternalUserRole",
                columns: new[] { "InternalUserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("0273e6a7-702a-48e9-8296-4f3a83509c5b"), "fe232d35-f62d-407f-995b-1934d38d96cc" },
                    { new Guid("7347bf3c-0ab6-4f66-b8ee-4bfe41f54dcc"), "fe232d35-f62d-407f-995b-1934d38d96cc" },
                    { new Guid("dff2ddeb-9e4e-4120-b699-b1d4157fb39d"), "fe232d35-f62d-407f-995b-1934d38d96cc" }
                });
        }
    }
}
