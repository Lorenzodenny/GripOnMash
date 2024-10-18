using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GripOnMash.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntaInternalUserAccess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InternalUserAccess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricola = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Accesso = table.Column<DateTime>(type: "datetime", nullable: false),
                    Uscita = table.Column<DateTime>(type: "datetime", nullable: true),
                    ScadenzaToken = table.Column<DateTime>(type: "datetime", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalUserAccess", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternalUserAccess");
        }
    }
}
