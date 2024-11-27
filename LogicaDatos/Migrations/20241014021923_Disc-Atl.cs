using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaDatos.Migrations
{
    /// <inheritdoc />
    public partial class DiscAtl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Atletas_AtletaId",
                table: "Disciplinas");

            migrationBuilder.DropIndex(
                name: "IX_Disciplinas_AtletaId",
                table: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "AtletaId",
                table: "Disciplinas");

            migrationBuilder.RenameColumn(
                name: "nombreDisciplina_Valor",
                table: "Disciplinas",
                newName: "NombreDisciplina_Valor");

            migrationBuilder.CreateTable(
                name: "AtletaDisciplina",
                columns: table => new
                {
                    _atletasId = table.Column<int>(type: "int", nullable: false),
                    _disciplinasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtletaDisciplina", x => new { x._atletasId, x._disciplinasId });
                    table.ForeignKey(
                        name: "FK_AtletaDisciplina_Atletas__atletasId",
                        column: x => x._atletasId,
                        principalTable: "Atletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtletaDisciplina_Disciplinas__disciplinasId",
                        column: x => x._disciplinasId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtletaDisciplina__disciplinasId",
                table: "AtletaDisciplina",
                column: "_disciplinasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtletaDisciplina");

            migrationBuilder.RenameColumn(
                name: "NombreDisciplina_Valor",
                table: "Disciplinas",
                newName: "nombreDisciplina_Valor");

            migrationBuilder.AddColumn<int>(
                name: "AtletaId",
                table: "Disciplinas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_AtletaId",
                table: "Disciplinas",
                column: "AtletaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Atletas_AtletaId",
                table: "Disciplinas",
                column: "AtletaId",
                principalTable: "Atletas",
                principalColumn: "Id");
        }
    }
}
