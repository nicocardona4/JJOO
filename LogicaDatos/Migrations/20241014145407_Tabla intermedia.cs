using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaDatos.Migrations
{
    /// <inheritdoc />
    public partial class Tablaintermedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtletaDisciplina_Atletas__atletasId",
                table: "AtletaDisciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_AtletaDisciplina_Disciplinas__disciplinasId",
                table: "AtletaDisciplina");

            migrationBuilder.RenameColumn(
                name: "_disciplinasId",
                table: "AtletaDisciplina",
                newName: "DisciplinaId");

            migrationBuilder.RenameColumn(
                name: "_atletasId",
                table: "AtletaDisciplina",
                newName: "AtletaId");

            migrationBuilder.RenameIndex(
                name: "IX_AtletaDisciplina__disciplinasId",
                table: "AtletaDisciplina",
                newName: "IX_AtletaDisciplina_DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtletaDisciplina_Atletas_AtletaId",
                table: "AtletaDisciplina",
                column: "AtletaId",
                principalTable: "Atletas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtletaDisciplina_Disciplinas_DisciplinaId",
                table: "AtletaDisciplina",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtletaDisciplina_Atletas_AtletaId",
                table: "AtletaDisciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_AtletaDisciplina_Disciplinas_DisciplinaId",
                table: "AtletaDisciplina");

            migrationBuilder.RenameColumn(
                name: "DisciplinaId",
                table: "AtletaDisciplina",
                newName: "_disciplinasId");

            migrationBuilder.RenameColumn(
                name: "AtletaId",
                table: "AtletaDisciplina",
                newName: "_atletasId");

            migrationBuilder.RenameIndex(
                name: "IX_AtletaDisciplina_DisciplinaId",
                table: "AtletaDisciplina",
                newName: "IX_AtletaDisciplina__disciplinasId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtletaDisciplina_Atletas__atletasId",
                table: "AtletaDisciplina",
                column: "_atletasId",
                principalTable: "Atletas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtletaDisciplina_Disciplinas__disciplinasId",
                table: "AtletaDisciplina",
                column: "_disciplinasId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
