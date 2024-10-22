using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GripOnMash.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntaTabellaEsitoQuestionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "EsitoQuestionario",
                columns: table => new
                {
                    EsitoQuestionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicoBaseId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    DomandaId = table.Column<int>(type: "int", nullable: false),
                    RispostaId = table.Column<int>(type: "int", nullable: false),
                    PazienteIdoneo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EsitoQuestionario", x => x.EsitoQuestionarioId);
                    table.ForeignKey(
                        name: "FK_EsitoQuestionario_AspNetUsers_MedicoBaseId",
                        column: x => x.MedicoBaseId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EsitoQuestionario_Domanda_DomandaId",
                        column: x => x.DomandaId,
                        principalTable: "Domanda",
                        principalColumn: "DomandaId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EsitoQuestionario_Risposta_RispostaId",
                        column: x => x.RispostaId,
                        principalTable: "Risposta",
                        principalColumn: "RispostaId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EsitoQuestionario_DomandaId",
                table: "EsitoQuestionario",
                column: "DomandaId");

            migrationBuilder.CreateIndex(
                name: "IX_EsitoQuestionario_MedicoBaseId",
                table: "EsitoQuestionario",
                column: "MedicoBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_EsitoQuestionario_RispostaId",
                table: "EsitoQuestionario",
                column: "RispostaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EsitoQuestionario");
        }
    }
}
