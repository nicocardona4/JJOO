using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaDatos.Migrations
{
    /// <inheritdoc />
    public partial class Participciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtletaId = table.Column<int>(type: "int", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false),
                    EventoNombrePrueba = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Puntuacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participaciones_Atletas_AtletaId",
                        column: x => x.AtletaId,
                        principalTable: "Atletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participaciones_Eventos_EventoNombrePrueba",
                        column: x => x.EventoNombrePrueba,
                        principalTable: "Eventos",
                        principalColumn: "NombrePrueba",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participaciones_AtletaId",
                table: "Participaciones",
                column: "AtletaId");

            migrationBuilder.CreateIndex(
                name: "IX_Participaciones_EventoNombrePrueba",
                table: "Participaciones",
                column: "EventoNombrePrueba");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participaciones");
        }
    }
}
