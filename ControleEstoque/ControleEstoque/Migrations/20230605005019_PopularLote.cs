using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleEstoque.Migrations
{
    public partial class PopularLote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Lote(LoteId,Referencia,FornecedorId) " +
            "VALUES('1', '642154782', '1')");

            migrationBuilder.Sql("INSERT INTO Lote(LoteId,Referencia,FornecedorId) " +
            "VALUES('2', '128471287', '2')");

            migrationBuilder.Sql("INSERT INTO Lote(LoteId,Referencia,FornecedorId) " +
            "VALUES('3', '065784734', '3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Lote");
        }
    }
}
