using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GripOnMash.Migrations
{
    /// <inheritdoc />
    public partial class SeedMediciDiBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a9999779-ae40-4692-9aa5-38a891953a2d", 0, "d75fe8d3-8dee-4451-b9a4-8c0c9ea3e5ff", "medicobase1@gmail.com", true, true, null, "MEDICOBASE1@GMAIL.COM", "MEDICOBASE1", "AQAAAAIAAYagAAAAEEM7p/jwg6PZ87SOvLla7Df8HX0qinMQRa7t/C/wh9yzMi0gn7oEAD3rGUz93PqZ8g==", null, false, "19d6edb3-3dc4-49c5-9b50-97d722613773", false, "medicoBase1" },
                    { "bce2fa92-4ec6-4bc1-87f1-ba64f25fc5b8", 0, "c692da41-4006-4658-a6ea-68c2785e0db0", "medicobase2@gmail.com", true, true, null, "MEDICOBASE2@GMAIL.COM", "MEDICOBASE2", "AQAAAAIAAYagAAAAEPiIOb+1yGu02GKuzXT6IYsA25Q1kjhKTW/NjLSLiVViyx34qBrX7DnhwM2hdF0Utw==", null, false, "506e62c1-d882-472c-b4e9-4237df77aa6a", false, "medicoBase2" }
                });

            migrationBuilder.InsertData(
                table: "InternalUser",
                columns: new[] { "Id", "Cognome", "IsEnabled", "Matricola", "Nome" },
                values: new object[,]
                {
                    { new Guid("8b89d683-a564-4f2e-a7b3-aadc5c008d32"), "Rossi", true, "sb004194", "Mario" },
                    { new Guid("b8999386-ac1b-47f7-9a90-2bdd4bb88ca9"), "Silveri", true, "sb004193", "Marco" },
                    { new Guid("f691dc5c-31e0-4e4d-8061-2d2952e4faca"), "Picchi", true, "00665539", "Daniele" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "a9999779-ae40-4692-9aa5-38a891953a2d" },
                    { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "bce2fa92-4ec6-4bc1-87f1-ba64f25fc5b8" }
                });

            migrationBuilder.InsertData(
                table: "InternalUserRole",
                columns: new[] { "InternalUserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("8b89d683-a564-4f2e-a7b3-aadc5c008d32"), "fe232d35-f62d-407f-995b-1934d38d96cc" },
                    { new Guid("b8999386-ac1b-47f7-9a90-2bdd4bb88ca9"), "fe232d35-f62d-407f-995b-1934d38d96cc" },
                    { new Guid("f691dc5c-31e0-4e4d-8061-2d2952e4faca"), "fe232d35-f62d-407f-995b-1934d38d96cc" }
                });

            migrationBuilder.InsertData(
                table: "MedicoBaseAnagrafica",
                columns: new[] { "MedicoBaseAnagraficaId", "CodiceFiscale", "Cognome", "EmailPersonale", "Eta", "IdentityId", "Indirizzo", "Nome", "NumeroAlbo", "NumeroTelefono", "PartitaIVA", "Specializzazione" },
                values: new object[,]
                {
                    { 1, "VRDGPP75E20H501Y", "Verdi", "giuseppe.verdi@gmail.com", 45, "a9999779-ae40-4692-9aa5-38a891953a2d", "Via Roma 1, Milano", "Giuseppe", "12345MI", "123456789", "12345678901", "Cardiologia" },
                    { 2, "BNCFNC82C15H501Z", "Bianchi", "francesca.bianchi@gmail.com", 38, "bce2fa92-4ec6-4bc1-87f1-ba64f25fc5b8", "Via Torino 10, Torino", "Francesca", "67890TO", "987654321", "98765432109", "Dermatologia" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "a9999779-ae40-4692-9aa5-38a891953a2d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "447b3ca6-bd0b-4e83-baf9-2de7069c10c5", "bce2fa92-4ec6-4bc1-87f1-ba64f25fc5b8" });

            migrationBuilder.DeleteData(
                table: "MedicoBaseAnagrafica",
                keyColumn: "MedicoBaseAnagraficaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MedicoBaseAnagrafica",
                keyColumn: "MedicoBaseAnagraficaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9999779-ae40-4692-9aa5-38a891953a2d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bce2fa92-4ec6-4bc1-87f1-ba64f25fc5b8");

        }
    }
}
