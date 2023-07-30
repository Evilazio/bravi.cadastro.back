using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bravi.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_ContatoTipos_contatoTipoId",
                table: "Contatos");

            migrationBuilder.RenameColumn(
                name: "valor",
                table: "Contatos",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "contatoTipoId",
                table: "Contatos",
                newName: "ContatoTipoId");

            migrationBuilder.RenameIndex(
                name: "IX_Contatos_contatoTipoId",
                table: "Contatos",
                newName: "IX_Contatos_ContatoTipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_ContatoTipos_ContatoTipoId",
                table: "Contatos",
                column: "ContatoTipoId",
                principalTable: "ContatoTipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_ContatoTipos_ContatoTipoId",
                table: "Contatos");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Contatos",
                newName: "valor");

            migrationBuilder.RenameColumn(
                name: "ContatoTipoId",
                table: "Contatos",
                newName: "contatoTipoId");

            migrationBuilder.RenameIndex(
                name: "IX_Contatos_ContatoTipoId",
                table: "Contatos",
                newName: "IX_Contatos_contatoTipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_ContatoTipos_contatoTipoId",
                table: "Contatos",
                column: "contatoTipoId",
                principalTable: "ContatoTipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
