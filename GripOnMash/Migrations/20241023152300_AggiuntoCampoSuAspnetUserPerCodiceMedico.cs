using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GripOnMash.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntoCampoSuAspnetUserPerCodiceMedico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "CodiceRandomico",
                table: "AspNetUsers",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CodiceRandomico",
                table: "AspNetUsers");

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
    }
}
