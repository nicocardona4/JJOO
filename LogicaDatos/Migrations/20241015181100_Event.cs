using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaDatos.Migrations
{
    /// <inheritdoc />
    public partial class Event : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventoNombrePrueba",
                table: "Atletas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    NombrePrueba = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    FechaInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.NombrePrueba);
                    table.ForeignKey(
                        name: "FK_Eventos_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atletas_EventoNombrePrueba",
                table: "Atletas",
                column: "EventoNombrePrueba");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_DisciplinaId",
                table: "Eventos",
                column: "DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atletas_Eventos_EventoNombrePrueba",
                table: "Atletas",
                column: "EventoNombrePrueba",
                principalTable: "Eventos",
                principalColumn: "NombrePrueba");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atletas_Eventos_EventoNombrePrueba",
                table: "Atletas");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Atletas_EventoNombrePrueba",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "EventoNombrePrueba",
                table: "Atletas");
        }
    }
}
