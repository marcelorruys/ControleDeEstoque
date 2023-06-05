using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleEstoque.Migrations
{
    public partial class PopularCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categoria(CategoriaId,CategoriaNome,Descricao) " +
            "VALUES('1', 'Escolar', 'Materias escolares')");

            migrationBuilder.Sql("INSERT INTO Categoria(CategoriaId,CategoriaNome,Descricao) " +
            "VALUES('2', 'Eletrônicos', 'Produtos eletrônicos')");

            migrationBuilder.Sql("INSERT INTO Categoria(CategoriaId,CategoriaNome,Descricao) " +
            "VALUES('3', 'Vidraçaria', 'Produtos de vidro e derivados')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categoria");
        }
    }
}
