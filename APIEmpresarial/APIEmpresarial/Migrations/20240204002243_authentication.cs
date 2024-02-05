using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIEmpresarial.Migrations
{
    /// <inheritdoc />
    public partial class authentication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Estoque_EstoqueId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_EstoqueId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "EstoqueId",
                table: "Livros");

            migrationBuilder.AddColumn<int>(
                name: "Perfil",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "Funcionarios");

            migrationBuilder.AddColumn<int>(
                name: "EstoqueId",
                table: "Livros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_EstoqueId",
                table: "Livros",
                column: "EstoqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Estoque_EstoqueId",
                table: "Livros",
                column: "EstoqueId",
                principalTable: "Estoque",
                principalColumn: "EstoqueId");
        }
    }
}
