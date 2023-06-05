using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleEstoque.Migrations
{
    public partial class PopularProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produto(ProdutoId,Nome,DescricaoDetalhada,IsProdutoPreferido,EstoqueMinimo,CategoriaId,LoteId,Estoque,EstoqueMaximo) " +
            "VALUES('1', 'Caderno', 'Caderno aspiral da marca Herint', '0', '5', '1', '1', '8', '10')");

            migrationBuilder.Sql("INSERT INTO Produto(ProdutoId,Nome,DescricaoDetalhada,IsProdutoPreferido,EstoqueMinimo,CategoriaId,LoteId,Estoque,EstoqueMaximo) " +
            "VALUES('2', 'Televisão', 'Televisão 60 polegadas da DigitalMax', '1', '10', '2', '2', '12', '20')");

            migrationBuilder.Sql("INSERT INTO Produto(ProdutoId,Nome,DescricaoDetalhada,IsProdutoPreferido,EstoqueMinimo,CategoriaId,LoteId,Estoque,EstoqueMaximo) " +
            "VALUES('3', 'Taças', 'Jogo de taças de cristal da Diamond Crytal', '0', '8', '3', '3', '13', '16')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produto(DELETE FROM Produto");
        }
    }
}
