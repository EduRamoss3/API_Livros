using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIEmpresarial.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Estoques__EstoqueEstoqueId",
                table: "Livros");

            migrationBuilder.DropTable(
                name: "Estoques");

            migrationBuilder.DropIndex(
                name: "IX_Livros__EstoqueEstoqueId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "_EstoqueEstoqueId",
                table: "Livros");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "_EstoqueEstoqueId",
                table: "Livros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Estoques",
                columns: table => new
                {
                    EstoqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantidade = table.Column<float>(type: "float", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoques", x => x.EstoqueId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Livros__EstoqueEstoqueId",
                table: "Livros",
                column: "_EstoqueEstoqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Estoques__EstoqueEstoqueId",
                table: "Livros",
                column: "_EstoqueEstoqueId",
                principalTable: "Estoques",
                principalColumn: "EstoqueId");
        }
    }
}
