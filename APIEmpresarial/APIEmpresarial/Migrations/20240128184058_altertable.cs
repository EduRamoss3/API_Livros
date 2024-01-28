using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIEmpresarial.Migrations
{
    /// <inheritdoc />
    public partial class altertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeLivro",
                table: "Estoque",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeLivro",
                table: "Estoque");
        }
    }
}
