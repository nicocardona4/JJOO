using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaDatos.Migrations
{
    /// <inheritdoc />
    public partial class fkEvento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participaciones_Eventos_EventoNombrePrueba",
                table: "Participaciones");

            migrationBuilder.DropIndex(
                name: "IX_Participaciones_EventoNombrePrueba",
                table: "Participaciones");

            migrationBuilder.DropColumn(
                name: "EventoNombrePrueba",
                table: "Participaciones");

            migrationBuilder.AlterColumn<string>(
                name: "EventoId",
                table: "Participaciones",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Participaciones_EventoId",
                table: "Participaciones",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participaciones_Eventos_EventoId",
                table: "Participaciones",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "NombrePrueba",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participaciones_Eventos_EventoId",
                table: "Participaciones");

            migrationBuilder.DropIndex(
                name: "IX_Participaciones_EventoId",
                table: "Participaciones");

            migrationBuilder.AlterColumn<int>(
                name: "EventoId",
                table: "Participaciones",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "EventoNombrePrueba",
                table: "Participaciones",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Participaciones_EventoNombrePrueba",
                table: "Participaciones",
                column: "EventoNombrePrueba");

            migrationBuilder.AddForeignKey(
                name: "FK_Participaciones_Eventos_EventoNombrePrueba",
                table: "Participaciones",
                column: "EventoNombrePrueba",
                principalTable: "Eventos",
                principalColumn: "NombrePrueba",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
