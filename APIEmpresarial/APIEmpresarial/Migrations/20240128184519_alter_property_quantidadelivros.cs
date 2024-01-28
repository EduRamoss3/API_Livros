using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIEmpresarial.Migrations
{
    /// <inheritdoc />
    public partial class alter_property_quantidadelivros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "QuantidadeLivros",
                table: "Estoque",
                type: "int",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float",
                oldMaxLength: 300);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "QuantidadeLivros",
                table: "Estoque",
                type: "float",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 300);
        }
    }
}
