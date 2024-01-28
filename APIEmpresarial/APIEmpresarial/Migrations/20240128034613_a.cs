using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIEmpresarial.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "QuantidadeVenda",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataVenda",
                table: "Vendas",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TotalGasto",
                table: "Gastos",
                type: "double",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataGasto",
                table: "Gastos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LivroId",
                table: "Estoque",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_LivroId",
                table: "Estoque",
                column: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Livros_LivroId",
                table: "Estoque",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "LivroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Livros_LivroId",
                table: "Estoque");

            migrationBuilder.DropIndex(
                name: "IX_Estoque_LivroId",
                table: "Estoque");

            migrationBuilder.DropColumn(
                name: "LivroId",
                table: "Estoque");

            migrationBuilder.AlterColumn<int>(
                name: "QuantidadeVenda",
                table: "Vendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataVenda",
                table: "Vendas",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalGasto",
                table: "Gastos",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataGasto",
                table: "Gastos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }
    }
}
