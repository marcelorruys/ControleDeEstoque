using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleEstoque.Migrations
{
    public partial class UpdateDomainModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Lote_LoteId",
                table: "Fornecedor");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedor_LoteId",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Lote");

            migrationBuilder.DropColumn(
                name: "LoteId",
                table: "Fornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Lote_FornecedorId",
                table: "Lote",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lote_Fornecedor_FornecedorId",
                table: "Lote",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "FornecedorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lote_Fornecedor_FornecedorId",
                table: "Lote");

            migrationBuilder.DropIndex(
                name: "IX_Lote_FornecedorId",
                table: "Lote");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Lote",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoteId",
                table: "Fornecedor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_LoteId",
                table: "Fornecedor",
                column: "LoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Lote_LoteId",
                table: "Fornecedor",
                column: "LoteId",
                principalTable: "Lote",
                principalColumn: "LoteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
