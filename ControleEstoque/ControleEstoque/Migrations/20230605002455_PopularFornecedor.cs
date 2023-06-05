using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleEstoque.Migrations
{
    public partial class PopularFornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Fornecedor(FornecedorId,Nome,RazaoSocial,Cnpj,Telefone,Email,Endereco1,Endereco2,Cep,Estado,Cidade,DescricaoDetalhada) " +
            "VALUES('1', 'Distribuidora Luiza', 'Luiza e Fabiana Distribuidora de Associados Ltda', '44384600168', '11987588615', 'almoxarifado@luizaefabianadistribuidoraassociadosltda.com.br', 'Rua Juvêncio Gomes, 984', null, '12948125', 'SP', 'Atibaia', 'A Distribuidora Luiza e Fabiana é responsável pelo fornecimento de produtos gerais.')");

            migrationBuilder.Sql("INSERT INTO Fornecedor(FornecedorId,Nome,RazaoSocial,Cnpj,Telefone,Email,Endereco1,Endereco2,Cep,Estado,Cidade,DescricaoDetalhada) " +
            "VALUES('2', 'Beatriz Eletrônica', 'Beatriz e Manuela Eletrônica ME', '27587732000', '11996684786', 'orcamento@beatrizemanuelaeletronicame.com.br', 'Rua Cachoeira Duas Araras, 272', 'Lote T43', '08475160', 'SP', 'São Paulo', 'Os fornecedores Beatriz e Manuela Eletrônica são responsáveis pelo fornecimento de produtos eletrônicos.')");

            migrationBuilder.Sql("INSERT INTO Fornecedor(FornecedorId,Nome,RazaoSocial,Cnpj,Telefone,Email,Endereco1,Endereco2,Cep,Estado,Cidade,DescricaoDetalhada) " +
            "VALUES('3', 'Isaac Vidros', 'Isaac e Bryan Vidros ME', '91553678157', '11997919258', 'contato@isaacebryanvidrosme.com.br', 'Rua Hermânia, 839', null, '04297030', 'SP', 'São Paulo', 'A Distribuidora Isaac e Bryan Vidros é responsável pelo fornecimento de produtos de vidro em geral.')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM fornecedor");
        }
    }
}
