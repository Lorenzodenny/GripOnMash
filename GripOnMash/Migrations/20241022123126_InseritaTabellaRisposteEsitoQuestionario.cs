using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GripOnMash.Migrations
{
    /// <inheritdoc />
    public partial class InseritaTabellaRisposteEsitoQuestionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EsitoQuestionario_Domanda_DomandaId",
                table: "EsitoQuestionario");

            migrationBuilder.DropForeignKey(
                name: "FK_EsitoQuestionario_Risposta_RispostaId",
                table: "EsitoQuestionario");

            migrationBuilder.DropIndex(
                name: "IX_EsitoQuestionario_DomandaId",
                table: "EsitoQuestionario");

            migrationBuilder.DropIndex(
                name: "IX_EsitoQuestionario_RispostaId",
                table: "EsitoQuestionario");

            

            migrationBuilder.DropColumn(
                name: "DomandaId",
                table: "EsitoQuestionario");

            migrationBuilder.DropColumn(
                name: "RispostaId",
                table: "EsitoQuestionario");

            migrationBuilder.CreateTable(
                name: "RisposteEsitoQuestionario",
                columns: table => new
                {
                    RisposteEsitoQuestionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomandaId = table.Column<int>(type: "int", nullable: false),
                    RispostaId = table.Column<int>(type: "int", nullable: false),
                    EsitoQuestionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RisposteEsitoQuestionario", x => x.RisposteEsitoQuestionarioId);
                    table.ForeignKey(
                        name: "FK_RisposteEsitoQuestionario_Domanda_DomandaId",
                        column: x => x.DomandaId,
                        principalTable: "Domanda",
                        principalColumn: "DomandaId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RisposteEsitoQuestionario_EsitoQuestionario_EsitoQuestionarioId",
                        column: x => x.EsitoQuestionarioId,
                        principalTable: "EsitoQuestionario",
                        principalColumn: "EsitoQuestionarioId");
                    table.ForeignKey(
                        name: "FK_RisposteEsitoQuestionario_Risposta_RispostaId",
                        column: x => x.RispostaId,
                        principalTable: "Risposta",
                        principalColumn: "RispostaId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RisposteEsitoQuestionario_DomandaId",
                table: "RisposteEsitoQuestionario",
                column: "DomandaId");

            migrationBuilder.CreateIndex(
                name: "IX_RisposteEsitoQuestionario_EsitoQuestionarioId",
                table: "RisposteEsitoQuestionario",
                column: "EsitoQuestionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RisposteEsitoQuestionario_RispostaId",
                table: "RisposteEsitoQuestionario",
                column: "RispostaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RisposteEsitoQuestionario");

            migrationBuilder.AddColumn<int>(
                name: "DomandaId",
                table: "EsitoQuestionario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RispostaId",
                table: "EsitoQuestionario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EsitoQuestionario_DomandaId",
                table: "EsitoQuestionario",
                column: "DomandaId");

            migrationBuilder.CreateIndex(
                name: "IX_EsitoQuestionario_RispostaId",
                table: "EsitoQuestionario",
                column: "RispostaId");

            migrationBuilder.AddForeignKey(
                name: "FK_EsitoQuestionario_Domanda_DomandaId",
                table: "EsitoQuestionario",
                column: "DomandaId",
                principalTable: "Domanda",
                principalColumn: "DomandaId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EsitoQuestionario_Risposta_RispostaId",
                table: "EsitoQuestionario",
                column: "RispostaId",
                principalTable: "Risposta",
                principalColumn: "RispostaId",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
