using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GripOnMash.Migrations
{
    /// <inheritdoc />
    public partial class CreazioneTabelleNelDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appuntamento",
                columns: table => new
                {
                    AppuntamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodiceGenerato = table.Column<int>(type: "int", nullable: false),
                    DataAppuntamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentityId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appuntamento", x => x.AppuntamentoId);
                    table.ForeignKey(
                        name: "FK_Appuntamento_AspNetUsers_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Domanda",
                columns: table => new
                {
                    DomandaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomandaTesto = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domanda", x => x.DomandaId);
                });

            migrationBuilder.CreateTable(
                name: "InternalUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Matricola = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Cognome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicoBaseAnagrafica",
                columns: table => new
                {
                    MedicoBaseAnagraficaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Cognome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Eta = table.Column<int>(type: "int", nullable: false),
                    NumeroTelefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    CodiceFiscale = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    Indirizzo = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Specializzazione = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    NumeroAlbo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    EmailPersonale = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    PartitaIVA = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoBaseAnagrafica", x => x.MedicoBaseAnagraficaId);
                    table.ForeignKey(
                        name: "FK_MedicoBaseAnagrafica_AspNetUsers_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NumeroPrenotazione",
                columns: table => new
                {
                    NumeroPrenotazioneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinRange = table.Column<int>(type: "int", nullable: false),
                    MaxRange = table.Column<int>(type: "int", nullable: false),
                    IsFull = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeroPrenotazione", x => x.NumeroPrenotazioneId);
                });

            migrationBuilder.CreateTable(
                name: "Risposta",
                columns: table => new
                {
                    RispostaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RispostaTesto = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    IsCorretta = table.Column<bool>(type: "bit", nullable: false),
                    DomandaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risposta", x => x.RispostaId);
                    table.ForeignKey(
                        name: "FK_Risposta_Domanda_DomandaId",
                        column: x => x.DomandaId,
                        principalTable: "Domanda",
                        principalColumn: "DomandaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    AgendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiornoSettimana = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ValidoDalGiorno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidoFinoAlGiorno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OraInizio = table.Column<TimeSpan>(type: "time", nullable: false),
                    NumeroMassimoPazienti = table.Column<int>(type: "int", nullable: false),
                    InternalUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.AgendaId);
                    table.ForeignKey(
                        name: "FK_Agenda_InternalUser_InternalUserId",
                        column: x => x.InternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternalUserRole",
                columns: table => new
                {
                    InternalUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalUserRole", x => new { x.InternalUserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_InternalUserRole_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalUserRole_InternalUser_InternalUserId",
                        column: x => x.InternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_InternalUserId",
                table: "Agenda",
                column: "InternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appuntamento_IdentityId",
                table: "Appuntamento",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalUserRole_RoleId",
                table: "InternalUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoBaseAnagrafica_IdentityId",
                table: "MedicoBaseAnagrafica",
                column: "IdentityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Risposta_DomandaId",
                table: "Risposta",
                column: "DomandaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Appuntamento");

            migrationBuilder.DropTable(
                name: "InternalUserRole");

            migrationBuilder.DropTable(
                name: "MedicoBaseAnagrafica");

            migrationBuilder.DropTable(
                name: "NumeroPrenotazione");

            migrationBuilder.DropTable(
                name: "Risposta");

            migrationBuilder.DropTable(
                name: "InternalUser");

            migrationBuilder.DropTable(
                name: "Domanda");
        }
    }
}
