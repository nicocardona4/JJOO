using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaDatos.Migrations
{
    /// <inheritdoc />
    public partial class Eventoatleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atletas_Eventos_EventoNombrePrueba",
                table: "Atletas");

            migrationBuilder.DropIndex(
                name: "IX_Atletas_EventoNombrePrueba",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "EventoNombrePrueba",
                table: "Atletas");

            migrationBuilder.CreateTable(
                name: "AtletaEvento",
                columns: table => new
                {
                    AtletasId = table.Column<int>(type: "int", nullable: false),
                    _eventosNombrePrueba = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtletaEvento", x => new { x.AtletasId, x._eventosNombrePrueba });
                    table.ForeignKey(
                        name: "FK_AtletaEvento_Atletas_AtletasId",
                        column: x => x.AtletasId,
                        principalTable: "Atletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtletaEvento_Eventos__eventosNombrePrueba",
                        column: x => x._eventosNombrePrueba,
                        principalTable: "Eventos",
                        principalColumn: "NombrePrueba",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtletaEvento__eventosNombrePrueba",
                table: "AtletaEvento",
                column: "_eventosNombrePrueba");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtletaEvento");

            migrationBuilder.AddColumn<string>(
                name: "EventoNombrePrueba",
                table: "Atletas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atletas_EventoNombrePrueba",
                table: "Atletas",
                column: "EventoNombrePrueba");

            migrationBuilder.AddForeignKey(
                name: "FK_Atletas_Eventos_EventoNombrePrueba",
                table: "Atletas",
                column: "EventoNombrePrueba",
                principalTable: "Eventos",
                principalColumn: "NombrePrueba");
        }
    }
}
